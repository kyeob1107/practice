﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practice6_user_input_radio_button_
{
    public partial class userinput : Form
    {
        bool prediction_1;
        public userinput()
        {
            InitializeComponent();
            //textBox_result.Text = prediction_1.ToString(); //초기값 뭘로 되어있나 확인용
        }
        public bool Coin_toss_result(bool prediction)
        {
            // 난수 객체 생성 및 이용하여 정수 생성
            Random random = new Random();
            int coin_pre_process = random.Next();
            bool coin;
            bool result;

            //랜덤 값을 동전 상태(bool)로 정의
            if (coin_pre_process % 2 == 0)
            {
                coin = false;
            }
            else
            {
                coin = true;
            }

            // 예측결과 bool로 저장
            result = coin == prediction;

            // 원하는대로 잘 되었는지 확인하기 위한 디버깅용
            string prediction_str;
            string coin_str;
            //예측부분 문자열변환
            if (prediction) { prediction_str = "앞면"; }
            else { prediction_str = "뒷면"; }
            //랜덤부분 문자열변환
            if (coin) { coin_str = "앞면"; }
            else { coin_str = "뒷면"; }
            textBox_result.Text += prediction.ToString() + "\r\n";
            textBox_result.Text += $"예측은 {prediction_str}\r\n실제는 {coin_str}";

            return result;
        }

        public void print(bool prediction)
        {
            string result_text;

            // 결과 확인 및 출력
            if (Coin_toss_result(prediction))
            {
                result_text = "승리";
            }
            else
            {
                result_text = "패배";
            }

            textBox_result.Text += $"\r\n동전던지기의 예측 결과는 {result_text}!";
        }

        private void button_input_Click(object sender, EventArgs e)
        {
            textBox_result.Text = "";
            //textBox_result.Text = textBox_input.Text;
            List<string> true_means = new List<string> { "T", "true" };
            List<string> false_means = new List<string> { "F", "false" };

            if (true_means.Any(s => s == textBox_input.Text))
            {
                prediction_1 = true;
                textBox_result.Text = "True로 체크확인";
            }
            else if (false_means.Any(s => s == textBox_input.Text))
            {
                prediction_1 = false;
                textBox_result.Text = "False로 체크확인";
            }
            print(prediction_1);
        }
        private void radioButton_true_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox_input.Text == "")
            {
                prediction_1 = true;
                //MessageBox.Show("라디오 True");
            }
            print(prediction_1);
        }

        private void radioButton_false_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox_input.Text == "")
            {
                prediction_1 = false;
                //MessageBox.Show("라디오 False");
            }
            print(prediction_1);
        }
    }
}