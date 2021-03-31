using System; 
using System.Drawing; 
using System.Windows.Forms;
using System.Globalization; // odpiwiada za CultureInfo.CreateSpecificCulture("en-US")

using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("Progro Watch")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("ZED1200")]
[assembly: AssemblyProduct("Progro Watch")]
[assembly: AssemblyCopyright("Free")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: AssemblyVersion("0.1.*")]

namespace Kolejny_Zegarek
{
	public class MainForm:Form 
	{

		Timer timer;
		private Label label1 = new Label(); 
		private Label label_Godziny = new Label();
		private Label label_Minuty_i_Sekunty = new Label();
		private Label label_Dzien_Tygodnia = new Label();
		
		public DateTime AKUTALNY_CZAS = new DateTime();
		ProgressBar progressBar_sekundy;
		ProgressBar progressBar_minuty;
		ProgressBar progressBar_godziny;
		ProgressBar progressBar_dzien_tydognia;
		
		public string sDzienTygodnia;
		public int iNumerDnia = new int ();
		
		private void Timer_Tick(object sender, EventArgs e)
		{
			AKUTALNY_CZAS = DateTime.Now;
			progressBar_sekundy.Value = int.Parse(AKUTALNY_CZAS.ToString("ss")); 
			progressBar_minuty.Value = int.Parse(AKUTALNY_CZAS.ToString("mm")); 
			progressBar_godziny.Value = int.Parse(AKUTALNY_CZAS.ToString("HH")); 
			
			label1.Text = (AKUTALNY_CZAS.ToString("yyyy/MM/dd")); 
			
			sDzienTygodnia = (AKUTALNY_CZAS.ToString("dddd ", CultureInfo.CreateSpecificCulture("en-US")));
			
			switch (sDzienTygodnia)
			{
				case "Monday ":
					iNumerDnia = 0;
					break;
				case "Tuesday ":
					iNumerDnia = 1;
					break;
				case "Wednesday ":
					iNumerDnia = 2;
					break;
				case "Thursday ":
					iNumerDnia = 3;
					break;
				case "Friday ":
					iNumerDnia = 4;
					break;
				case "Saturday ":
					iNumerDnia = 5;
					break;
				case "Sunday ":
					iNumerDnia = 6;
					break;
			}

			progressBar_dzien_tydognia.Value = iNumerDnia;
		}

		public MainForm() 
		{
		Width = 320; 
		Height = 255; 
		Text= "Progro Watch"; 
	
		int top_dla_progres_bar = new int ();
		top_dla_progres_bar = 30;

		label1.Top = 175; 
		label1.Left = (ClientSize.Width - label1.Width) / 2; 
		label1.Font = new Font("Arial",12);
		label1.Size = new System.Drawing.Size(100, 40);
		label1.TextAlign = ContentAlignment.MiddleCenter; 
	
		label_Godziny.Top = 15; 
		label_Godziny.Left = 9;
		label_Godziny.Font = new Font("Arial",7); 
		label_Godziny.Size = new System.Drawing.Size(300, 15);
		label_Godziny.Text ="    .   2   .   4   .   6   .  8   .  10  .  12  .  14  .  16  .  18  .  20  .  22  .  ";
	
		label_Minuty_i_Sekunty.Top = 85; 
		label_Minuty_i_Sekunty.Left = 10;
		label_Minuty_i_Sekunty.Font = new Font("Arial",8); 
		label_Minuty_i_Sekunty.Size = new System.Drawing.Size(300, 20);
		label_Minuty_i_Sekunty.Text ="0... .5....10....15....20....25...30....35....40....45....50....55....";
	
		label_Dzien_Tygodnia.Top = 135; //15
		label_Dzien_Tygodnia.Left = 5;
		label_Dzien_Tygodnia.Font = new Font("Arial",7); 
		label_Dzien_Tygodnia.Size = new System.Drawing.Size(300, 15);
		label_Dzien_Tygodnia.Text ="Pon.         Wt.            Śr.           Czw.          Pią.          Sob.         Nie.";

		progressBar_sekundy = new ProgressBar();
		progressBar_sekundy.Location = new Point(10, top_dla_progres_bar + 75);
		progressBar_sekundy.Width = 280;
		progressBar_sekundy.Minimum = 0;
		progressBar_sekundy.Maximum = 59;
		progressBar_sekundy.Style = ProgressBarStyle.Continuous; //Block domyslny
	
		progressBar_minuty = new ProgressBar();
		progressBar_minuty.Location = new Point(10, top_dla_progres_bar + 30);
		progressBar_minuty.Width = 280;
		progressBar_minuty.Minimum = 0;
		progressBar_minuty.Maximum = 59;
		progressBar_minuty.Style = ProgressBarStyle.Continuous; //Block domyslny
	
		progressBar_godziny = new ProgressBar();
		progressBar_godziny.Location = new Point(10, top_dla_progres_bar);
		progressBar_godziny.Width = 280;
		progressBar_godziny.Minimum = 0;
		progressBar_godziny.Maximum = 23;
		progressBar_godziny.Style = ProgressBarStyle.Continuous; //Block domyslny
	
		progressBar_dzien_tydognia = new ProgressBar();
		progressBar_dzien_tydognia.Location = new Point(10, (top_dla_progres_bar+120));
		progressBar_dzien_tydognia.Width = 280;
		progressBar_dzien_tydognia.Minimum = 0;
		progressBar_dzien_tydognia.Maximum = 6;
		progressBar_dzien_tydognia.Style = ProgressBarStyle.Continuous; //Block domyslny		
	
		Controls.Add(label1); 
		Controls.Add(label_Godziny);
		Controls.Add(label_Minuty_i_Sekunty);
		Controls.Add(label_Dzien_Tygodnia);
		Controls.Add(progressBar_sekundy);
		Controls.Add(progressBar_minuty);
		Controls.Add(progressBar_godziny);	
		Controls.Add(progressBar_dzien_tydognia);
	
		timer = new Timer();
		timer.Interval = 1000;
		timer.Tick += Timer_Tick;
		timer.Start();
	
		}
		[STAThread]
		public static void Main() 
		{
			Application.Run(new MainForm()); 
		}
	}
}
