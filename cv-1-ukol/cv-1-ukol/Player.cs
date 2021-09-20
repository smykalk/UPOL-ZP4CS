using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_1_ukol {
	class Player : IComparable<Player> {
		string name;
		int number;
		int matches;
		int goals;
		int assists;
		
		public Player(string name, int num, int mat, int goal, int ass) {
			this.name = name;
			this.number = num;
			this.matches = mat;
			this.goals = goal;
			this.assists = ass;
		}

		public int pointsAssists {
			get { 
				return this.goals + this.assists;
			}
		}

		public int CompareTo(Player pl) {
			int p1 = this.pointsAssists;
			int p2 = pl.pointsAssists;
			if (p1 < p2)
				return -1;
			else if (p1 > p2)
				return 1;
			else
				return 0;
		}

		public override string ToString() {
			return String.Format("Name: {0}, Number: {1}, Matches: {2}, Goals: {3}, Assists: {4}",name,number,matches,goals, assists);
		}
	}
}
