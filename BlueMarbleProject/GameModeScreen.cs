﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueMarbleProject
{
    public partial class GameModeScreen : Form
    {
        public GameModeScreen()
        {
            InitializeComponent();
        }

        private void GameModeScreen_FormClosing(object sender, FormClosingEventArgs e) //Hide()를 썼으면 필연적으로 따라와야 됨
        {
            Application.Exit();
        }

        private void SelectTeam_RadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            P2_RadioBtn.Enabled = false; // 팀전을 선택할 시 2, 3인은 선택 불가 
            P3_RadioBtn.Enabled = false;
            P2_RadioBtn.Checked = false; // 자동 체크 해제(2인 선택 후 팀 모드로 바꿔버리면 그대로 체크됨 방지)
            P3_RadioBtn.Checked = false;
        }

        private void SelectSolo_RadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            P2_RadioBtn.Enabled = true; // 유동적으로 선택가능
            P3_RadioBtn.Enabled = true;
        }
        private void Start_Btn_Click(object sender, EventArgs e) // 모두 선택 시 게임 시작
        {
            bool P2BtnClicked = P2_RadioBtn.Checked; // 2p선택 후 값 전달
            bool P3BtnClicked = P3_RadioBtn.Checked; // 3p선택 후 값 전달
            bool P4BtnClicked = P4_RadioBtn.Checked; // 4p선택 후 값 전달
            bool Team_BtnClicked = SelectTeam_RadioBtn.Checked; // 팀전 선택 값 전달
            bool Solo_BtnClicked = SelectTeam_RadioBtn.Checked; // 개인전 선택 값 전달

            MainBoard Main_Form = new MainBoard(P2BtnClicked, P3BtnClicked, P4BtnClicked, Team_BtnClicked, Solo_BtnClicked);

            if (SelectTeam_RadioBtn.Checked == true || SelectSolo_RadioBtn.Checked == true) // 게임 모드 선택하고
            {
                if (P2_RadioBtn.Checked == true || P3_RadioBtn.Checked == true || P4_RadioBtn.Checked == true) // 인원수 선택 시
                {
                    Main_Form.Show(); // 게임 시작 (보드판 띄우기)
                    this.Hide();
                }
                else
                    MessageBox.Show("인원수를 선택해주세요."); // 안 고를 시 띄우는 박스
            }
            else
                MessageBox.Show("게임 모드를 선택해주세요."); // 안 고를 시 띄우는 박스
        }
    }
}