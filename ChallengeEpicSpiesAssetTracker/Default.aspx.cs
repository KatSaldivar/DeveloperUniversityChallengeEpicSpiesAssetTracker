﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeEpicSpiesAssetTracker
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string[] assets = new string[0];
                int[] elections = new int[0];
                int[] subterfuge = new int[0];

                ViewState.Add("Assets", assets);
                ViewState.Add("Elections", elections);
                ViewState.Add("Subterfuge", subterfuge);
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            string[] assets = (string[])ViewState["Assets"];
            int[] elections = (int[])ViewState["Elections"];
            int[] subterfuge = (int[])ViewState["Subterfuge"];

            int newLength = assets.Length + 1;

            Array.Resize(ref assets, newLength);
            Array.Resize(ref elections, newLength);
            Array.Resize(ref subterfuge, newLength);

            int newIndex = assets.GetUpperBound(0);

            assets[newIndex] = nameTextBox.Text;
            elections[newIndex] = int.Parse(electionTextBox.Text);
            subterfuge[newIndex] = int.Parse(subterfugeTextBox.Text);

            ViewState["Assets"] = assets;
            ViewState["Elections"] = elections;
            ViewState["Subterfuge"] = subterfuge;

            resultLabel.Text = String.Format("Total elections rigged: {0}"
                + "<br />Average acts of subterfuge per asset: {1:N2}"
                + "<br />Last asset added: {2}",
                elections.Sum(),
                subterfuge.Average(),
                assets[newIndex]);

            nameTextBox.Text = "";
            electionTextBox.Text = "";
            subterfugeTextBox.Text = "";
        }
    }
}