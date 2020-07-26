using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewerSMBW_Music_Challenge_Generator
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        List<Song> songs = new List<Song>();
        string originalPath;
        bool doRefresh = true;
        bool doRefreshListBox = true;
        bool doComboRefresh = true;
        string AbsolutelyEverything = "";

        int[] noteblocks = {0, 1, 2, 3, 4, 5, 6};
        bool isPlayingMusic = false;
        bool doStopMusic = false;
        int whatamiplaying = 0; //0 = nothing; 1 = song; 2 = sequence;

        bool isLoaded = false;

        public string GetBetweenStrings(string input, string before, string after, bool keepAfter)
        {
            int indexBefore = input.IndexOf(before) + before.Length;
            int indexAfter = input.IndexOf(after);

            return input.Substring(indexBefore, indexAfter - indexBefore + ((keepAfter) ? after.Length : 0));
        }

        public void loadFile(string path)
        {
            //Get the Song & Tempo data in a string
            AbsolutelyEverything = File.ReadAllText(path);

            int beforeCut = AbsolutelyEverything.IndexOf("int Tempo");
            int afterCut = AbsolutelyEverything.IndexOf("const char* Prizes");

            string data = AbsolutelyEverything.Substring(beforeCut, afterCut - beforeCut);


            //Get the tempos
            List<int> tempos = new List<int>();

            string tempoList = GetBetweenStrings(data, "{", "}", false).Replace(" ", "").Replace("	", "").Replace("\n", "") + ",";
            for (int i = 0; i < 16; i++)
            {
                String tempoToGet = tempoList.Substring(0, tempoList.IndexOf(","));
                tempos.Add(Convert.ToInt32(tempoToGet));
                tempoList = tempoList.Substring(tempoList.IndexOf(",") + 1);
            }

            //Get the songs
            string songData = data.Substring(data.IndexOf("{ //")).Replace("	", "");

            for(int songID = 0; songID < 15; songID++)
            {
                //Get song data
                string currentSong = GetBetweenStrings(songData, "{ // Song", "}}\n},", true);
                songData = songData.Replace(currentSong, "");

                if(songID == 5 && currentSong.IndexOf("// Fuck") >= 0)
                {
                    currentSong = currentSong.Substring(0, currentSong.IndexOf("// Fuck") - 1) + "},"; //Remove commented song if it exists
                }


                //Get song infos
                Song thisSong = new Song();
                int currentSongID = Convert.ToInt32(((songID > 0) ? GetBetweenStrings(currentSong, "// Song ", " - ", false) : GetBetweenStrings(currentSong, " ", " - ", false)));
                string currentSongName = GetBetweenStrings(currentSong, " - ", " |", false);
                int currentSongTempo = tempos[songID];
                int currentDifficulty = GetBetweenStrings(currentSong, " |", "|\n", false).Split('*').Length - 1;
                thisSong.id = currentSongID;
                thisSong.name = currentSongName;
                thisSong.tempo = currentSongTempo;
                thisSong.difficulty = currentDifficulty;

                //Get song sequences
                string sequenceData = "{{" + GetBetweenStrings(currentSong, "{{", "}}\n", true);
                for(int sequenceID = 0; sequenceID < 4; sequenceID++)
                {
                    string currentSequence = sequenceData.Split('\n')[sequenceID];
                    currentSequence = currentSequence.Substring(1, currentSequence.IndexOf("}}"));
                    int noteCount = (currentSequence.Split(',').Length - 1) / 3;

                    Sequence thisSequence = new Sequence();
                    //Get notes data
                    for(int noteID = 0; noteID < noteCount; noteID++)
                    {
                        string noteData = currentSequence.Substring(1, currentSequence.IndexOf("},{") - 1);

                        int currentNoteBlock = Convert.ToInt32(noteData.Split(',')[0]);
                        int currentNoteSFX = Convert.ToInt32(noteData.Split(',')[1]);
                        int currentNoteTiming = Convert.ToInt32(noteData.Split(',')[2]);

                        currentSequence = currentSequence.Replace("{" + noteData + "},", "");
                        Note thisNote = new Note(currentNoteBlock, currentNoteSFX, currentNoteTiming);
                        thisSequence.notes.Add(thisNote);
                    }
                    thisSong.sequences.Add(thisSequence);
                }

                songs.Add(thisSong);
            }
            refreshListBox();
            refreshComboBox();
            EnableBoxes();
        }

        public string saveFile()
        {
            //Writing Tempos
            string data = "";
            data += "int Tempo[16] = {";
            for(int currentTempo = 0; currentTempo < songs.Count; currentTempo++)
            {
                data += songs[currentTempo].tempo + ",";
            }
            data += "8};\n\n\n";


            //Writing Songs
            data += "int Songs[16][4][16][3] = {\n\n";
            foreach (Song currentSong in songs)
            {
                //Writing Song Infos
                string difficulty = "";
                for (int star = 0; star < 5; star++)
                {
                    if (currentSong.difficulty > star) {
                        difficulty += "*";
                    }
                    else
                    {
                        difficulty += " ";
                    }
                }
                data += "	{ // Song " + currentSong.id + " - " + currentSong.name + " |" + difficulty + "|\n";


                //Writing Sequences
                for(int currentSequence = 0; currentSequence < 4; currentSequence++)
                {
                    data += "		{";

                    foreach(Note currentNote in currentSong.sequences[currentSequence].notes)
                    {
                        data += "{" + currentNote.block + "," + currentNote.sfx + "," + currentNote.timing + "},";
                    }

                    data += "{0,0,0}}" + ((currentSequence == 3) ? "\n" : ",\n");
                }

                //Adding Misc. Stuff
                data += "	},\n\n";
            }

            //Adding Placeholder 16th Song
            data += "	{ // Song 16 - Overworld or Cave\n";
            data += "		{{0,0,0}},\n";
            data += "		{{0,0,0}},\n";
            data += "		{{0,0,0}},\n";
            data += "		{{0,0,0}}\n";
            data += "	}\n";
            data += "};\n\n";

            //Sparating header and footer from original file
            string header = GetBetweenStrings(AbsolutelyEverything, "", "int Tempo", false);
            string footer = AbsolutelyEverything.Substring(AbsolutelyEverything.IndexOf("const char* Prizes"));

            //Combine everything
            string finalData = header + data + footer;

            //Return it
            return finalData;
        }

        public void refreshListBox()
        {
            for (int i = 0; i < songs.Count; i++)
            {
                if (i < musicListBox.Items.Count)
                {
                    object nyeh = ("Song " + songs[i].id + " - " + songs[i].name);
                    musicListBox.Items[i] = nyeh;
                }
                else
                {
                    musicListBox.Items.Add("Song " + songs[i].id + " - " + songs[i].name);
                }
            }
        }

        public void refreshComboBox()
        {
            noteComboBox.Items.Clear();
            if(sequenceComboBox.SelectedIndex < 0)
            {
                doComboRefresh = false;
                sequenceComboBox.SelectedIndex = 0;
            }
            if(musicListBox.SelectedIndex < 0)
            {
                doComboRefresh = false;
                musicListBox.SelectedIndex = 0;
            }
            for (int i = 0; i < songs[musicListBox.SelectedIndex].sequences[sequenceComboBox.SelectedIndex].notes.Count; i++)
            {
                object nyeh = ("Note " + i);
                noteComboBox.Items.Add(nyeh);
            }
            noteComboBox.SelectedIndex = 0;
        }

        public void EnableBoxes()
        {
            musicListBox.Enabled = true;
            outputTextBox.Enabled = true;
            songButton.Enabled = true;
            playButton.Enabled = true;
            idNumBox.Enabled = true;
            difficultyNumBox.Enabled = true;
            tempoNumBox.Enabled = true;
            nameTextBox.Enabled = true;
            sequenceComboBox.Enabled = true;
            noteComboBox.Enabled = true;
            blockNumBox.Enabled = true;
            sfxComboBox.Enabled = true;
            timingNumBox.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            blockLabel.Enabled = true;
            idLabel.Enabled = true;
            difficultyLabel.Enabled = true;
            tempoLabel.Enabled = true;
            outputLabel.Enabled = true;
            nameLabel.Enabled = true;
            sfxLabel.Enabled = true;
            timingLabel.Enabled = true;
            musicListBox.Enabled = true;
            settingsGroupBox.Enabled = true;
            noteGroupBox.Enabled = true;
            musicGroupBox.Enabled = true;
            isLoaded = true;
        }

        public void resetBoxes()
        {
            isRedLighted = false;
            isOrangeLighted = false;
            isYellowLighted = false;
            isGreenLighted = false;
            isBlueLighted = false;
            isCyanLighted = false;
            isPurpleLighted = false;
        }

        public int frameToMilliseconds(int frameCount)
        {
            return (int)(frameCount / 0.06);
        }

        string[] NotesName =
        {
            "3C",
            "3C#",
            "3D",
            "3D#",
            "3E",
            "3F",
            "3F#",
            "3G",
            "3G#",
            "3A",
            "3A#",
            "3B",
            "4C",
            "4C#",
            "4D",
            "4D#",
            "4E",
            "4F",
            "4F#",
            "4G",
            "4G#",
            "4A",
            "4A#",
            "4B"
        };

        public void PlaySoundID(int songID, int sequenceID)
        {
            int previousTiming = 0;
            int previousBlock = 0;
            isPlayingMusic = true;
            for (int noteID = 0; noteID < songs[songID].sequences[sequenceID].notes.Count; noteID++)
            {
                if(doStopMusic)
                {
                    doStopMusic = false;
                    isPlayingMusic = false;
                    return;
                }

                int block = songs[songID].sequences[sequenceID].notes[noteID].block;

                int framesToWait = (songs[songID].sequences[sequenceID].notes[noteID].timing - previousTiming) * songs[songID].tempo;

                System.Threading.Thread.Sleep(frameToMilliseconds(framesToWait / 2));
                if (previousBlock == 1) { isRedLighted = false; }
                if (previousBlock == 2) { isOrangeLighted = false; }
                if (previousBlock == 3) { isYellowLighted = false; }
                if (previousBlock == 4) { isGreenLighted = false; }
                if (previousBlock == 5) { isBlueLighted = false; }
                if (previousBlock == 6) { isCyanLighted = false; }
                if (previousBlock == 7) { isPurpleLighted = false; }
                System.Threading.Thread.Sleep(frameToMilliseconds(framesToWait / 2));


                previousTiming = songs[songID].sequences[sequenceID].notes[noteID].timing;
                previousBlock = block;

                if (block == 1) { isRedLighted = true;  }
                if(block == 2) { isOrangeLighted = true;  }
                if(block == 3) { isYellowLighted = true;  }
                if(block == 4) { isGreenLighted = true;  }
                if(block == 5) { isBlueLighted = true;  }
                if(block == 6) { isCyanLighted = true;  }
                if(block == 7) { isPurpleLighted = true;  }


                SoundPlayer audio = new SoundPlayer();
                int sfx = songs[songID].sequences[sequenceID].notes[noteID].sfx;

                noteblocks[block - 1] = sfx - 1;

                if (doStopMusic)
                {
                    isPlayingMusic = false;
                    return;
                }

                System.Threading.Thread.Sleep(1);
                if (sfx == 1)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3C);
                }
                if (sfx == 2)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3C_);
                }
                if (sfx == 3)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3D);
                }
                if (sfx == 4)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3D_);
                }
                if (sfx == 5)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3E);
                }
                if (sfx == 6)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3F);
                }
                if (sfx == 7)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3F_);
                }
                if (sfx == 8)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3G);
                }
                if (sfx == 9)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3G_);
                }
                if (sfx == 10)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3A);
                }
                if (sfx == 11)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3A_);
                }
                if (sfx == 12)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3B);
                }
                if (sfx == 13)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4C);
                }
                if (sfx == 14)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4C_);
                }
                if (sfx == 15)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4D);
                }
                if (sfx == 16)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4D_);
                }
                if (sfx == 17)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4E);
                }
                if (sfx == 18)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4F);
                }
                if (sfx == 19)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4F_);
                }
                if (sfx == 20)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4G);
                }
                if (sfx == 21)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4G_);
                }
                if (sfx == 22)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4A);
                }
                if (sfx == 23)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4A_);
                }
                if (sfx == 24)
                {
                    audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4B);
                }
                audio.Play();
            }
            System.Threading.Thread.Sleep(1000);
            if (previousBlock == 1) { isRedLighted = false; }
            if (previousBlock == 2) { isOrangeLighted = false; }
            if (previousBlock == 3) { isYellowLighted = false; }
            if (previousBlock == 4) { isGreenLighted = false; }
            if (previousBlock == 5) { isBlueLighted = false; }
            if (previousBlock == 6) { isCyanLighted = false; }
            if (previousBlock == 7) { isPurpleLighted = false; }
            isPlayingMusic = false;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            outputTextBox.Enabled = false;
            songButton.Enabled = false;
            playButton.Enabled = false;
            idNumBox.Enabled = false;
            difficultyNumBox.Enabled = false;
            tempoNumBox.Enabled = false;
            nameTextBox.Enabled = false;
            sequenceComboBox.Enabled = false;
            noteComboBox.Enabled = false;
            blockNumBox.Enabled = false;
            sfxComboBox.Enabled = false;
            timingNumBox.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            blockLabel.Enabled = false;
            idLabel.Enabled = false;
            difficultyLabel.Enabled = false;
            tempoLabel.Enabled = false;
            outputLabel.Enabled = false;
            nameLabel.Enabled = false;
            sfxLabel.Enabled = false;
            timingLabel.Enabled = false;
            musicListBox.Enabled = false;
            settingsGroupBox.Enabled = false;
            noteGroupBox.Enabled = false;
            musicGroupBox.Enabled = false;
            playButton.Enabled = false;
            songButton.Enabled = false;

            redNote.SelectedIndex = 0;
            orangeNote.SelectedIndex = 2;
            yellowNote.SelectedIndex = 4;
            greenNote.SelectedIndex = 5;
            blueNote.SelectedIndex = 7;
            cyanNote.SelectedIndex = 9;
            purpleNote.SelectedIndex = 11;

            InitTimer();
        }

        private void musicListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (doRefreshListBox)
            {
                doRefresh = false;
                idNumBox.Value = songs[musicListBox.SelectedIndex].id;
                doRefresh = false;
                nameTextBox.Text = songs[musicListBox.SelectedIndex].name;
                doRefresh = false;
                tempoNumBox.Value = songs[musicListBox.SelectedIndex].tempo;
                doRefresh = false;
                difficultyNumBox.Value = songs[musicListBox.SelectedIndex].difficulty;
                refreshComboBox();
            }
            else
            {
                doRefreshListBox = true;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                string output;
                dialog.Filter = "NewerSMBW Music Challenge Source File|*.cpp|All files (*.*)|*.*";
                dialog.FilterIndex = 1;
                dialog.RestoreDirectory = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    songs = new List<Song>();
                    output = dialog.FileName;
                    loadFile(output);
                    originalPath = output;
                    this.Text = "NewerSMBW Music Challenge Generator - " + output.Split('\\')[output.Split('\\').Length - 1];
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string outputFile = saveFile();
            File.WriteAllText(originalPath, outputFile);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog textDialog;
            textDialog = new SaveFileDialog();
            textDialog.Filter = "NewerSMBW Music Challenge Source File|*.cpp|All files (*.*)|*.*";
            textDialog.DefaultExt = "cpp";
            if (textDialog.ShowDialog() == DialogResult.OK)
            {
                //Stream things to get the saved path
                System.IO.Stream fileStream = textDialog.OpenFile();
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fileStream);
                string outputPath = ((FileStream)(sw.BaseStream)).Name;
                sw.Close();
                originalPath = outputPath;
                this.Text = "NewerSMBW Music Challenge Generator - " + outputPath.Split('\\')[outputPath.Split('\\').Length - 1];

                //Save it
                string outputFile = saveFile();
                File.WriteAllText(outputPath, outputFile);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            DialogResult dialogresult = a.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                a.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void idNumBox_ValueChanged(object sender, EventArgs e)
        {
            songs[musicListBox.SelectedIndex].id = (int)idNumBox.Value;
            doRefreshListBox = false;
            object nyeh = ("Song " + songs[musicListBox.SelectedIndex].id + " - " + songs[musicListBox.SelectedIndex].name);
            musicListBox.Items[musicListBox.SelectedIndex] = nyeh;
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            songs[musicListBox.SelectedIndex].name = nameTextBox.Text;
            doRefreshListBox = false;
            object nyeh = ("Song " + songs[musicListBox.SelectedIndex].id + " - " + songs[musicListBox.SelectedIndex].name);
            musicListBox.Items[musicListBox.SelectedIndex] = nyeh;
        }

        private void tempoNumBox_ValueChanged(object sender, EventArgs e)
        {
            if (doRefresh)
            {
                songs[musicListBox.SelectedIndex].tempo = (int)tempoNumBox.Value;
            }
            else
            {
                doRefresh = true;
            }
        }

        private void difficultyNumBox_ValueChanged(object sender, EventArgs e)
        {
            if (doRefresh)
            {
                songs[musicListBox.SelectedIndex].difficulty = (int)difficultyNumBox.Value;
            }
            else
            {
                doRefresh = true;
            }
        }

        private void sequenceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (doComboRefresh)
            {
                refreshComboBox();
            }
            else
            {
                doComboRefresh = true;
            }
        }

        private void noteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            doRefresh = false;
            blockNumBox.Value = songs[musicListBox.SelectedIndex].sequences[sequenceComboBox.SelectedIndex].notes[noteComboBox.SelectedIndex].block;
            doRefresh = false;
            sfxComboBox.SelectedIndex = songs[musicListBox.SelectedIndex].sequences[sequenceComboBox.SelectedIndex].notes[noteComboBox.SelectedIndex].sfx - 1;
            doRefresh = false;
            timingNumBox.Minimum = songs[musicListBox.SelectedIndex].sequences[sequenceComboBox.SelectedIndex].notes[(noteComboBox.SelectedIndex == 0) ? 0 : noteComboBox.SelectedIndex - 1].timing;
            timingNumBox.Value = ((songs[musicListBox.SelectedIndex].sequences[sequenceComboBox.SelectedIndex].notes[noteComboBox.SelectedIndex].timing < timingNumBox.Minimum) ? timingNumBox.Minimum : songs[musicListBox.SelectedIndex].sequences[sequenceComboBox.SelectedIndex].notes[noteComboBox.SelectedIndex].timing);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (songs[musicListBox.SelectedIndex].sequences[sequenceComboBox.SelectedIndex].notes.Count < 15)
            {
                Note newNote = new Note(1, 1, songs[musicListBox.SelectedIndex].sequences[sequenceComboBox.SelectedIndex].notes[(noteComboBox.SelectedIndex == 0) ? 0 : noteComboBox.SelectedIndex].timing);
                songs[musicListBox.SelectedIndex].sequences[sequenceComboBox.SelectedIndex].notes.Insert(noteComboBox.SelectedIndex + 1, newNote);
                int newSelect = noteComboBox.SelectedIndex + 1;
                noteComboBox.SelectedIndex = 0;
                noteComboBox.Items.Clear();
                refreshComboBox();
                noteComboBox.SelectedIndex = newSelect;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("There can't be more than 15 notes in a song !");
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (songs[musicListBox.SelectedIndex].sequences[sequenceComboBox.SelectedIndex].notes.Count > 1)
            {
                songs[musicListBox.SelectedIndex].sequences[sequenceComboBox.SelectedIndex].notes.Remove(songs[musicListBox.SelectedIndex].sequences[sequenceComboBox.SelectedIndex].notes[noteComboBox.SelectedIndex]);
                int newSelect = ((noteComboBox.SelectedIndex == 0) ? 0 : (noteComboBox.SelectedIndex - 1));
                noteComboBox.SelectedIndex = 0;
                noteComboBox.Items.Clear();
                refreshComboBox();
                noteComboBox.SelectedIndex = newSelect;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("There can't be no notes in a song !");
            }
        }


        private void playButton_Click(object sender, EventArgs e)
        {
            if (isPlayingMusic)
            {
                doStopMusic = true;
                whatamiplaying = 0;
            }
            else
            {
                int mus = musicListBox.SelectedIndex;
                int seq = sequenceComboBox.SelectedIndex;
                outputTextBox.Text = "Starting Sequence " + seq + " from Song " + songs[musicListBox.SelectedIndex].id + "\n";
                whatamiplaying = 2;
                Task.Factory.StartNew(() =>
                {
                    PlaySoundID(mus, seq);
                    logseqs = 4;
                    doStopMusic = false;
                    resetBoxes();
                    whatamiplaying = 0;
                });
            }
        }

        int logseqs = -1;

        private void songButton_Click(object sender, EventArgs e)
        {
            if (isPlayingMusic)
            {
                doStopMusic = true;
                whatamiplaying = 0;
            }
            else
            {
                isPlayingMusic = true;
                int mus = musicListBox.SelectedIndex;
                outputTextBox.Text = "Starting Song " + songs[musicListBox.SelectedIndex].id + "\n";
                whatamiplaying = 1;
                Task.Factory.StartNew(() =>
                {
                    for (int seq = 0; seq < 4; seq++)
                    {
                        logseqs = seq;
                        PlaySoundID(mus, seq);
                        resetBoxes();
                        System.Threading.Thread.Sleep(1000);
                        if(doStopMusic)
                        {
                            doStopMusic = false;
                            return;
                        }
                    }
                    whatamiplaying = 0;
                });
            }
        }

        private void blockNumBox_ValueChanged(object sender, EventArgs e)
        {
            if (doRefresh)
            {
                songs[musicListBox.SelectedIndex].sequences[sequenceComboBox.SelectedIndex].notes[noteComboBox.SelectedIndex].block = (int)blockNumBox.Value;
            }
            else
            {
                doRefresh = true;
            }
        }

        private void sfxComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (doRefresh)
            {
                songs[musicListBox.SelectedIndex].sequences[sequenceComboBox.SelectedIndex].notes[noteComboBox.SelectedIndex].sfx = (int)sfxComboBox.SelectedIndex + 1;
            }
            else
            {
                doRefresh = true;
            }
        }

        private void timingNumBox_ValueChanged(object sender, EventArgs e)
        {
            if (doRefresh)
            {
                songs[musicListBox.SelectedIndex].sequences[sequenceComboBox.SelectedIndex].notes[noteComboBox.SelectedIndex].timing = (int)timingNumBox.Value;
            }
            else
            {
                doRefresh = true;
            }
        }

        public void PlaySFX(int sfxID)
        {
            sfxID++;
            SoundPlayer audio = new SoundPlayer();
            if (sfxID == 1)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3C);
            }
            if (sfxID == 2)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3C_);
            }
            if (sfxID == 3)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3D);
            }
            if (sfxID == 4)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3D_);
            }
            if (sfxID == 5)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3E);
            }
            if (sfxID == 6)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3F);
            }
            if (sfxID == 7)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3F_);
            }
            if (sfxID == 8)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3G);
            }
            if (sfxID == 9)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3G_);
            }
            if (sfxID == 10)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3A);
            }
            if (sfxID == 11)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3A_);
            }
            if (sfxID == 12)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._3B);
            }
            if (sfxID == 13)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4C);
            }
            if (sfxID == 14)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4C_);
            }
            if (sfxID == 15)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4D);
            }
            if (sfxID == 16)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4D_);
            }
            if (sfxID == 17)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4E);
            }
            if (sfxID == 18)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4F);
            }
            if (sfxID == 19)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4F_);
            }
            if (sfxID == 20)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4G);
            }
            if (sfxID == 21)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4G_);
            }
            if (sfxID == 22)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4A);
            }
            if (sfxID == 23)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4A_);
            }
            if (sfxID == 24)
            {
                audio = new SoundPlayer(NewerSMBW_Music_Challenge_Generator.Properties.Resources._4B);
            }
            audio.Play();
        }

        bool isRedLighted = false;
        bool isOrangeLighted = false;
        bool isYellowLighted = false;
        bool isGreenLighted = false;
        bool isBlueLighted = false;
        bool isCyanLighted = false;
        bool isPurpleLighted = false;

        private void redBlock_Click(object sender, EventArgs e)
        {
            int redSelected = redNote.SelectedIndex;
            Task.Factory.StartNew(() =>
            {
                isRedLighted = true;
                PlaySFX(redSelected);
                Thread.Sleep(500);
                isRedLighted = false;
            });
        }

        private void orangeBlock_Click(object sender, EventArgs e)
        {
            int orangeSelected = orangeNote.SelectedIndex;
            Task.Factory.StartNew(() =>
            {
                isOrangeLighted = true;
                PlaySFX(orangeSelected);
                Thread.Sleep(500);
                isOrangeLighted = false;
            });
        }

        private void yellowBlock_Click(object sender, EventArgs e)
        {
            int yellowSelected = yellowNote.SelectedIndex;
            Task.Factory.StartNew(() =>
            {
                isYellowLighted = true;
                PlaySFX(yellowSelected);
                Thread.Sleep(500);
                isYellowLighted = false;
            });
        }

        private void greenBlock_Click(object sender, EventArgs e)
        {
            int greenSelected = greenNote.SelectedIndex;
            Task.Factory.StartNew(() =>
            {
                isGreenLighted = true;
                PlaySFX(greenSelected);
                Thread.Sleep(500);
                isGreenLighted = false;
            });
        }

        private void blueBlock_Click(object sender, EventArgs e)
        {
            int blueSelected = blueNote.SelectedIndex;
            Task.Factory.StartNew(() =>
            {
                isBlueLighted = true;
                PlaySFX(blueSelected);
                Thread.Sleep(500);
                isBlueLighted = false;
            });
        }

        private void cyanBlock_Click(object sender, EventArgs e)
        {
            int cyanSelected = cyanNote.SelectedIndex;
            Task.Factory.StartNew(() =>
            {
                isCyanLighted = true;
                PlaySFX(cyanSelected);
                Thread.Sleep(500);
                isCyanLighted = false;
            });
        }

        private void purpleBlock_Click(object sender, EventArgs e)
        {
            int purpleSelected = purpleNote.SelectedIndex;
            Task.Factory.StartNew(() =>
            {
                isPurpleLighted = true;
                PlaySFX(purpleSelected);
                Thread.Sleep(500);
                isPurpleLighted = false;
            });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(isRedLighted)
            {
                redBlock.Image = Properties.Pictures.music_block_1_s;
            }
            else
            {
                redBlock.Image = Properties.Pictures.music_block_1;
            }

            if(isOrangeLighted)
            {
                orangeBlock.Image = Properties.Pictures.music_block_2_s;
            }
            else
            {
                orangeBlock.Image = Properties.Pictures.music_block_2;
            }

            if(isYellowLighted)
            {
                yellowBlock.Image = Properties.Pictures.music_block_3_s;
            }
            else
            {
                yellowBlock.Image = Properties.Pictures.music_block_3;
            }

            if(isGreenLighted)
            {
                greenBlock.Image = Properties.Pictures.music_block_4_s;
            }
            else
            {
                greenBlock.Image = Properties.Pictures.music_block_4;
            }

            if(isBlueLighted)
            {
                blueBlock.Image = Properties.Pictures.music_block_5_s;
            }
            else
            {
                blueBlock.Image = Properties.Pictures.music_block_5;
            }

            if(isCyanLighted)
            {
                cyanBlock.Image = Properties.Pictures.music_block_6_s;
            }
            else
            {
                cyanBlock.Image = Properties.Pictures.music_block_6;
            }

            if(isPurpleLighted)
            {
                purpleBlock.Image = Properties.Pictures.music_block_7_s;
            }
            else
            {
                purpleBlock.Image = Properties.Pictures.music_block_7;
            }

            if(logseqs >= 0)
            {
                if (logseqs < 4)
                {
                    outputTextBox.Text += "Starting Sequence " + (logseqs + 1) + "\n";
                }
                else
                {
                    outputTextBox.Text += "The End\n";
                }
                logseqs = -1;
            }

            if (isPlayingMusic)
            {
                redNote.SelectedIndex = noteblocks[0];
                orangeNote.SelectedIndex = noteblocks[1];
                yellowNote.SelectedIndex = noteblocks[2];
                greenNote.SelectedIndex = noteblocks[3];
                blueNote.SelectedIndex = noteblocks[4];
                cyanNote.SelectedIndex = noteblocks[5];
                purpleNote.SelectedIndex = noteblocks[6];
            }
            if (isLoaded)
            {
                if (whatamiplaying == 0)
                {
                    songButton.Enabled = true;
                    songButton.Text = "Play Song";
                    playButton.Enabled = true;
                    playButton.Text = "Play Sequence";
                }
                else if (whatamiplaying == 1)
                {
                    songButton.Enabled = true;
                    songButton.Text = "Stop Song";
                    playButton.Enabled = false;
                    playButton.Text = "Play Sequence";
                }
                else if (whatamiplaying == 2)
                {
                    songButton.Enabled = false;
                    songButton.Text = "Play Song";
                    playButton.Enabled = true;
                    playButton.Text = "Stop Sequence";
                }
            }
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("The timing consists of the time the note will wait minus the previous one, times the tempo\n\nI know it isn't clear, so here's an example:\nIf the previous note's timing was 12\nand this note's timing is 16\nand the song's tempo is 13,\nthen this note will wait ((16 - 12) * 13) = 52 frames before being played.\n\nKnowing the game runs at 60fps, then the note will wait ~0.866 seconds before being played\n\nTherefore, it is highly recommended to set the first note's timing to 0 so the song plays immediatly when it has to play.");
        }
    }
    public class Note
    {
        internal int block;
        internal int sfx;
        internal int timing;
        public Note(int newBlock, int newNote, int newTiming)
        {
            block = newBlock;
            sfx = newNote;
            timing = newTiming;
        }
    }
    public class Sequence
    {
        internal List<Note> notes = new List<Note>();
    }
    public class Song
    {
        internal int id;
        internal string name;
        internal int tempo;
        internal int difficulty;
        internal List<Sequence> sequences = new List<Sequence>();

    }
}
