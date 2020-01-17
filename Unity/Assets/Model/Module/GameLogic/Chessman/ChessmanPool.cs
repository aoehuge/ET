using System;
using System.Collections.Generic;

namespace ETModel
{
    public class ChessmanPool
    {
        public static ChessmanPool instance = new ChessmanPool();

        private readonly Dictionary<long, Queue<Chessman>> allChessmans = new Dictionary<long, Queue<Chessman>>();

        private readonly Dictionary<ChessmanType, Dictionary<long,int>> chessmanDics = new Dictionary<ChessmanType, Dictionary<long, int>>();

        private readonly Dictionary<ChessmanType, List<long>> chessmanKinds = new Dictionary<ChessmanType, List<long>>();

        private readonly Random randomNum = new Random();

        private readonly ChessmanType[] ChessmanTypes = new ChessmanType[] {
            ChessmanType.OneStar,
            ChessmanType.TwoStar,
            ChessmanType.ThreeStar,
            ChessmanType.FourStar,
            ChessmanType.FiveStar
        };

        public void Init()
        {
            foreach (var chessmanType in ChessmanTypes)
            {
                chessmanKinds.Add(chessmanType, new List<long>());
                chessmanDics.Add(chessmanType, new Dictionary<long, int>());
            }
            ConfigComponent configCom = Game.Scene.GetComponent<ConfigComponent>();

            IConfig[] chessmanConfigs = configCom.GetAll(typeof(ChessmanConfig));

            ChessmanConfig config;
            foreach (var chessmanConfig in chessmanConfigs)
            {
                config = (ChessmanConfig)chessmanConfig;
                chessmanDics[(ChessmanType)config.Star].Add(config.Id, this.GetChessmanNumByType((ChessmanType)config.Star));
                chessmanKinds[(ChessmanType)config.Star].Add(config.Id);
            }

        }

        private int GetChessmanNumByType(ChessmanType chessmanType)
        {
            return 10;
        }

        public Chessman Get(long chessmanId)
        {           
            Queue<Chessman> queue;
            if (!this.allChessmans.TryGetValue(chessmanId, out queue))
            {
                queue = new Queue<Chessman>();
                this.allChessmans.Add(chessmanId, queue);
            }

            Chessman chessman;
            if (queue.Count > 0)
            {
                chessman = queue.Dequeue();
            }
            else
            {
                chessman = Activator.CreateInstance<Chessman>();
            }

            return chessman;
        }

        public Chessman RandomPick()
        {
            long chessmanId = this.getRandomNum();


           
            Queue<Chessman> queue;
            if (!this.allChessmans.TryGetValue(chessmanId, out queue))
            {
                queue = new Queue<Chessman>();
                this.allChessmans.Add(chessmanId, queue);
            }

            Chessman chessman;
            if (queue.Count > 0)
            {
                chessman = queue.Dequeue();
            }
            else
            {
                chessman = Activator.CreateInstance<Chessman>();
            }

            return chessman;
        }

        private string[] getRatioByLevel(int level)
        {
            string str = "35-30-20-15-0";
            string[] strs = str.Split('-');
            return strs;
        }

        private long getRandomNum()
        {
            ChessmanType type = ChessmanType.OneStar;
            int randomInt = randomNum.Next(1,100);

            string[] strs = getRatioByLevel(1);

            int ratio = 0;
            for (int i = 0; i < strs.Length; i++)
            {
                ratio += Convert.ToInt32(strs[i]);
                if (randomInt < ratio)
                {
                    type = (ChessmanType)i+1;
                    break;
                }
            }

            if (chessmanKinds.TryGetValue(type, out List<long> chessList))
            {

                return chessList[randomNum.Next(1, chessList.Count)];
            }

            return 0;
        }
    }
}
