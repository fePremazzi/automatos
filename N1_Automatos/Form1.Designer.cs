using System.Windows.Forms;

namespace N1_Automatos
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoad = new System.Windows.Forms.Button();
            this.openAutomato = new System.Windows.Forms.OpenFileDialog();
            this.openIN_File = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadIN = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTransicao = new System.Windows.Forms.Button();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblEstados = new System.Windows.Forms.Label();
            this.lblAlfabeto = new System.Windows.Forms.Label();
            this.lblEstadoInicial = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblEstadoFinal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(21, 16);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(150, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Carregar autômato";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // openAutomato
            // 
            this.openAutomato.FileName = "openFileDialog1";
            // 
            // openIN_File
            // 
            this.openIN_File.FileName = "openFileDialog2";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnLoadIN
            // 
            this.btnLoadIN.Enabled = false;
            this.btnLoadIN.Location = new System.Drawing.Point(182, 16);
            this.btnLoadIN.Name = "btnLoadIN";
            this.btnLoadIN.Size = new System.Drawing.Size(150, 23);
            this.btnLoadIN.TabIndex = 1;
            this.btnLoadIN.Text = "Carregar e ler palavras";
            this.btnLoadIN.UseVisualStyleBackColor = true;
            this.btnLoadIN.Click += new System.EventHandler(this.loadIN_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 215);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(311, 92);
            this.textBox1.TabIndex = 0;
            this.textBox1.ScrollBars = ScrollBars.Vertical;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tipo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Estados:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Alfabeto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Estado inicial:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Funções de transição:";
            // 
            // btnTransicao
            // 
            this.btnTransicao.Enabled = false;
            this.btnTransicao.Location = new System.Drawing.Point(131, 179);
            this.btnTransicao.Name = "btnTransicao";
            this.btnTransicao.Size = new System.Drawing.Size(201, 23);
            this.btnTransicao.TabIndex = 3;
            this.btnTransicao.Text = "Exibir funções de transição";
            this.btnTransicao.UseVisualStyleBackColor = true;
            this.btnTransicao.Click += new System.EventHandler(this.transicao_Click);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(98, 54);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(10, 13);
            this.lblTipo.TabIndex = 2;
            this.lblTipo.Text = ".";
            // 
            // lblEstados
            // 
            this.lblEstados.AutoSize = true;
            this.lblEstados.Location = new System.Drawing.Point(98, 80);
            this.lblEstados.Name = "lblEstados";
            this.lblEstados.Size = new System.Drawing.Size(10, 13);
            this.lblEstados.TabIndex = 2;
            this.lblEstados.Text = ".";
            // 
            // lblAlfabeto
            // 
            this.lblAlfabeto.AutoSize = true;
            this.lblAlfabeto.Location = new System.Drawing.Point(98, 106);
            this.lblAlfabeto.Name = "lblAlfabeto";
            this.lblAlfabeto.Size = new System.Drawing.Size(10, 13);
            this.lblAlfabeto.TabIndex = 2;
            this.lblAlfabeto.Text = ".";
            // 
            // lblEstadoInicial
            // 
            this.lblEstadoInicial.AutoSize = true;
            this.lblEstadoInicial.Location = new System.Drawing.Point(98, 132);
            this.lblEstadoInicial.Name = "lblEstadoInicial";
            this.lblEstadoInicial.Size = new System.Drawing.Size(10, 13);
            this.lblEstadoInicial.TabIndex = 2;
            this.lblEstadoInicial.Text = ".";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Estados finais:";
            // 
            // lblEstadoFinal
            // 
            this.lblEstadoFinal.AutoSize = true;
            this.lblEstadoFinal.Location = new System.Drawing.Point(98, 158);
            this.lblEstadoFinal.Name = "lblEstadoFinal";
            this.lblEstadoFinal.Size = new System.Drawing.Size(10, 13);
            this.lblEstadoFinal.TabIndex = 2;
            this.lblEstadoFinal.Text = ".";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 326);
            this.Controls.Add(this.btnTransicao);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblEstadoFinal);
            this.Controls.Add(this.lblEstadoInicial);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblAlfabeto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblEstados);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnLoadIN);
            this.Controls.Add(this.btnLoad);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "N1_Automatos v1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog openAutomato;
        private System.Windows.Forms.OpenFileDialog openIN_File;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnLoadIN;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTransicao;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblEstados;
        private System.Windows.Forms.Label lblAlfabeto;
        private System.Windows.Forms.Label lblEstadoInicial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblEstadoFinal;
    }
}

