﻿using PopStudio.Platform;
using System.Windows.Controls;
using System.Windows.Documents;

namespace PopStudio.Plugin
{
    internal static partial class API
    {
        public static RichTextBox box;

        public static partial void Print(params object[] os)
        {
            string str = string.Empty;
            if (os.Length != 0)
            {
                string nil = "nil";
                for (int i = 0; i < os.Length; i++)
                {
                    str += ((os[i]?.ToString()) ?? nil) + ' ';
                }
                str = str[0..^1];
            }
            box.Dispatcher.BeginInvoke(() => { Paragraph para = new(); para.Inlines.Add(new Run(str)); box.Document.Blocks.Add(para); });
        }

        public static partial bool? Alert(string text, string title, bool ask)
        {
            bool? ans = null;
            bool a = false;
            if (ask)
            {
                box.Dispatcher.BeginInvoke(async () => { ans = await PopupDialog.DisplayAlert(title, text, "OK", "Cancel"); a = true; });
            }
            else
            {
                box.Dispatcher.BeginInvoke(async () => { await PopupDialog.DisplayAlert(title, text, "Cancel"); a = true; });
            }
            while (!a) Thread.Sleep(200);
            return ans;
        }

        public static partial string Prompt(string text, string title, string defaulttext)
        {
            string ans = null;
            bool a = false;
            box.Dispatcher.BeginInvoke(async () => { ans = await PopupDialog.DisplayPromptAsync(title, text, initialValue: defaulttext); a = true; });
            while (!a) Thread.Sleep(200);
            return ans;
        }

        public static partial string Sheet(string title, params string[] items)
        {
            string ans = null;
            bool a = false;
            box.Dispatcher.BeginInvoke(async () => { ans = await PopupDialog.DisplayActionSheet(title, "Cancel\0", "OK\0", items); a = true; });
            while (!a) Thread.Sleep(200);
            if (ans == "OK\0" && ans == "Cancel\0")
            {
                return null;
            }
            return ans;
        }

        public static partial string ChooseFolder()
        {
            string ans = null;
            bool a = false;
            box.Dispatcher.BeginInvoke(() =>
            {
                ans = WPF.PickFile.ChooseFolder(null);
                a = true;
            });
            while (!a) Thread.Sleep(200);
            return ans;
        }

        public static partial string ChooseOpenFile()
        {
            string ans = null;
            bool a = false;
            box.Dispatcher.BeginInvoke(() =>
            {
                ans = WPF.PickFile.ChooseOpenFile(null);
                a = true;
            });
            while (!a) Thread.Sleep(200);
            return ans;
        }

        public static partial string ChooseSaveFile()
        {
            string ans = null;
            bool a = false;
            box.Dispatcher.BeginInvoke(() =>
            {
                ans = WPF.PickFile.ChooseSaveFile(null);
                a = true;
            });
            while (!a) Thread.Sleep(200);
            return ans;
        }

        public static partial void OpenUrl(string url) => Permission.OpenUrl(url);
    }
}

