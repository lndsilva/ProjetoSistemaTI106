using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ConsultorioMedico
{
    public partial class frmFuncionarios : Form
    {
        public frmFuncionarios()
        {
            InitializeComponent();
            txtCodigo.Text = carregaCodigoFunc().ToString();
        }

        public int carregaCodigoFunc()
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select codfunc +1 from tbfuncionarios order by codfunc desc";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            int codigo = DR.GetInt32(0);

            Conexao.fecharConexao();

            return codigo;

        }


        public void cadastrarFuncionario()
        {
            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "insert into tbfuncionarios(nomefunc,emailfunc, telefone, cpf)values(@nomefunc,@emailfunc,@telefone,@cpf); ";

            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();

            comm.Parameters.Add("@nomefunc", MySqlDbType.VarChar, 100).Value = txtNome.Text;
            comm.Parameters.Add("@emailfunc", MySqlDbType.VarChar, 100).Value = txtEmail.Text;
            comm.Parameters.Add("@telefone", MySqlDbType.VarChar, 14).Value = mskTelefone.Text;
            comm.Parameters.Add("@cpf", MySqlDbType.VarChar, 14).Value = mskCPF.Text;

            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            int i = comm.ExecuteNonQuery();

            MessageBox.Show("Paciente cadastrado com sucesso!!!" + i);

            Conexao.fecharConexao();
        }

        public void cadastrarUsuario(int codigo)
        {
            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "insert into tbusuarios(nomeUsu,senhaUsu, codfunc)values(@nomeUsu,MD5('@senhaUsu'), " + codigo + ");";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();

            comm.Parameters.Add("@nomeUsu", MySqlDbType.VarChar, 100).Value = txtUsuario.Text;
            comm.Parameters.Add("@senhaUsu", MySqlDbType.VarChar, 100).Value = txtSenha.Text;
            

            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            int i = comm.ExecuteNonQuery();

            MessageBox.Show("Funcionário cadastrado com sucesso!!!" + i);

            Conexao.fecharConexao();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            cadastrarFuncionario();
            int codUsu = pesquisacodigo(Convert.ToInt32(txtCodigo.Text));
            cadastrarUsuario(Convert.ToInt32(codUsu));
        }

        public int pesquisacodigo(int codigo)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbfuncionarios where codFunc = '" + codigo + "';";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            codigo = DR.GetInt32(0);
           
            Conexao.fecharConexao();

            return codigo;
        }


        private void btnPesquisar_Click(object sender, EventArgs e)
        {

        }

        private void frmFuncionarios_Load(object sender, EventArgs e)
        {

        }
    }
}
