using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class MainForm : Form
    {
        private Population population;
        private Timer tickTimer = new Timer();

        public MainForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            DoubleBuffered = true;

            tickTimer.Tick += TickTimer_Tick;

            
        }


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams paras = base.CreateParams;
                paras.ExStyle |= 0x02000000;
                return paras;
            }
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            IncreaseGeneration();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ResetState();
            stopButton.Enabled = false;

            UpdateStatistics();
            UpdateInterval();
        }

        private void ResetState()
        {
            intervalBar.Value = 50;

            PopulationInitializer initializer = new PopulationInitializer();
            population = initializer.GetPopulation();

            populationPanel.SetPopulation(population);
        }

        private void IncreaseGeneration()
        {
            this.SuspendLayout();

            population.IncreaseGeneration();
            populationPanel.Invalidate();

            UpdateStatistics();

            this.ResumeLayout();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            resetButton.Enabled = false;
            startButton.Enabled = false;
            tickTimer.Start();
            stopButton.Enabled = true;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
            tickTimer.Stop();
            startButton.Enabled = true;
            resetButton.Enabled = true;
        }

        private void intervalBar_Scroll(object sender, EventArgs e)
        {
            UpdateInterval();
        }

        private void UpdateInterval()
        {
            int msInterval = intervalBar.Value;
            tickTimer.Interval = msInterval;
            intervalLabel.Text = $"{msInterval}ms";
        }

        private void populationPanel_UserChangedState(object sender, EventArgs e)
        {
            UpdateStatistics();
        }


        private void UpdateStatistics()
        {
            generationCountBox.Text = population.GenerationNumber.ToString();
            aliveCountBox.Text = population.AliveCount.ToString();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            ResetState();
            UpdateStatistics();
            UpdateInterval();
            populationPanel.Invalidate();
        }
    }
}
