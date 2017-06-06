using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KeplerBI.WinForm
{
    public partial class Form1 : mko.WinForm.FormWithTabControl
    {
        public Form1()
        {
            InitializeComponent();
        }

        KeplerBI.RAM.AstroCatalog catalog = new RAM.AstroCatalog();

        int AnzZeilen = 0;

        System.Threading.CancellationTokenSource cancelTokenSrc = new System.Threading.CancellationTokenSource();


        private async void btnCsvFileOpen_Click(object sender, EventArgs e)
        {
            if(openAsteroidsCSVFile.ShowDialog() == DialogResult.OK)
            {
                progressBar1.Value = 0;                

                if (System.IO.File.Exists(openAsteroidsCSVFile.FileName))
                {
                    var reader = new System.IO.StreamReader(openAsteroidsCSVFile.FileName);

                    // Alle Zeilen durchzählen
                    AnzZeilen = 0;
                    while (!reader.EndOfStream)
                    {
                        AnzZeilen++;
                        reader.ReadLine();
                    }

                    base.log.Log(mko.Log.RC.CreateMsg("Die CSV- Datei " + openAsteroidsCSVFile.FileName + " enthält " + AnzZeilen + " Zeilen"));

                    cancelTokenSrc = new System.Threading.CancellationTokenSource();
                    var cancelToken = cancelTokenSrc.Token;
                    var import = new KeplerBI.Dataimport.AsteroidImport(catalog, cancelToken);
                    import.ProgressInfo += Import_ProgressInfo;
                                        
                    try
                    {
                        await System.Threading.Tasks.Task.Run(() => import.Import(openAsteroidsCSVFile.FileName), cancelToken);

                        progressBar1.Value = 100;

                        var fssbld = catalog.Asteroids.createFiltertedSortedSetBuilder();
                        fssbld.OrderBySemiMajorAxisLength(false);

                        var res = fssbld.GetSet();
                        base.toolStripStatusLabelBaseForm.Text = "Anz. Asteroiden: " + res.Count();

                        AsteroidCatalogBindingSource.DataSource = res.Get();
                        AsteroidCatalogBindingSource.ResetBindings(false);

                    }
                    catch (System.OperationCanceledException)
                    {                        
                        log.Log(mko.Log.RC.CreateStatus("Import aus " + openAsteroidsCSVFile.FileName + " abgebrochen"));
                    }
                    
                }
                else
                {
                    base.log.Log(mko.Log.RC.CreateError("Die CSV-Datei " + openAsteroidsCSVFile.FileName + " konnte nicht für den Import geöffnet werden"));
                }
            }
        }

        private void Import_ProgressInfo(int arg1, int arg2)
        {
            var action = new Action(() => progressBar1.Value = (int)(100.0 * arg1)/AnzZeilen);

            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(action);
            }else
            {
                action();
            }
        }

        private void btnCsvImportCancel_Click(object sender, EventArgs e)
        {
            log.Log(mko.Log.RC.CreateStatus("Import aus " + openAsteroidsCSVFile.FileName + " wird abgebrochen ..."));
            cancelTokenSrc.Cancel();
        }
    }
}
