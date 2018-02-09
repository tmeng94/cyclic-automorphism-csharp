using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RunButton_Click(object sender, EventArgs e)
    {
        string word = InputString.Text;
        // Find matches in repeated string
        string str = word + word;

        if (word.Length == 0)
        {
            Result.Text = "We found 0 automorphs (empty string).";
        }
        else
        {
            List<int> ii = new List<int>();
            // Create KMP table
            int[] table = new int[word.Length];
            table[0] = -1;
            int pos = 1, cnd = 0;
            while (pos < word.Length)
            {
                if (word[pos] == word[cnd])
                {
                    table[pos] = table[cnd];
                    pos++;
                    cnd++;
                }
                else
                {
                    table[pos] = cnd;
                    cnd = table[cnd];
                    while (cnd > 0 && word[pos] != word[cnd]) cnd = table[cnd];
                    pos++;
                    cnd++;
                }
            }

            // Search from str[1]; str[0] must be a match
            int automorph = 0;
            int mpos = 1, ipos = 0;
            while (mpos + ipos < str.Length)
            {
                if (word[ipos] == str[mpos + ipos])
                {
                    if (ipos + 1 == word.Length)
                    {
                        // Occurence found, calculate automorphs by division
                        automorph = word.Length / mpos;
                        break;
                    }
                    else ipos++;
                }
                else
                {
                    if (table[ipos] > -1)
                    {
                        mpos += ipos - table[ipos];
                        ipos = table[ipos];
                    }
                    else
                    {
                        mpos = mpos + ipos + 1;
                        ipos = 0;
                    }
                }
            }
            Result.Text = "We found " + automorph.ToString() + " automorphs.";
        }
    }
}