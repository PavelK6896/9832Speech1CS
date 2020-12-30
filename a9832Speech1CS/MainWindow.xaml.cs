using System.Diagnostics;
using System.Speech.Synthesis;
using System.Windows;

namespace a9832Speech1CS
{
    public partial class MainWindow
    {
        private SpeechSynthesizer speechSynthesizer;

        public MainWindow()
        {
            //размер
            this.Height = 50;
            this.Width = 50;
            //положение
            this.Left = 50;
            this.Top = 50;
            speechSynthesizer = new SpeechSynthesizer();
            InitializeComponent();
            Button1.Click += Button_Click;

            //     [DllImport("User32.dll")]
            // protected static extern bool AddClipboardFormatListener(int hwnd);
        }

        private void Button_Click(object object1, RoutedEventArgs e)
        {
            foreach (InstalledVoice voice in speechSynthesizer.GetInstalledVoices())
            {
                VoiceInfo info = voice.VoiceInfo;

                if (info.Name == "IVONA 2 Tatyana OEM")
                {
                    speechSynthesizer.SelectVoice(info.Name);
                    Debug.WriteLine(info.Name);
                }

                // Debug.WriteLine(" Name:          " + info.Name);
                // Debug.WriteLine(" Culture:       " + info.Culture);
                // Debug.WriteLine(" Age:           " + info.Age);
                // Debug.WriteLine(" Gender:        " + info.Gender);
                // Debug.WriteLine(" Description:   " + info.Description);
                // Debug.WriteLine(" ID:            " + info.Id);
                // Debug.WriteLine(" Enabled:       " + voice.Enabled);
            }

            speechSynthesizer.Rate = 10;
            Debug.WriteLine(speechSynthesizer.Voice);
            Debug.WriteLine(speechSynthesizer.Rate);

            // speechSynthesizer.SetOutputToDefaultAudioDevice();

            if (Clipboard.ContainsText() == true)
            {
                string someText = Clipboard.GetText();
                speechSynthesizer.Speak(someText);
            }
            else
            {
                speechSynthesizer.Speak("просто текст");
            }
        }
    }
}