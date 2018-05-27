using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BlackJack_ByClass_
{
    class Program
    {
        static void Main(string[] args)
        {
            Card cardPack = new Card(52);
            Dealer dealer = new Dealer();
            Player[] player = new Player[4];
            int playerNumber = 1;
            int playerBustCounter = 0;
            bool isGameOver = false;

            for (int i = 0; i < 4; i++)
            {
                player[i] = new Player();
            }

            Console.WriteLine("게임을 시작합니다.");
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine("카드를 섞는 중입니다...");
            Thread.Sleep(2000);
            Console.WriteLine();
            Console.WriteLine("카드를 2장씩 받습니다.");
            Console.WriteLine();

            for (int i = 0; i < 2; i++)
            {
                dealer.DrawCards(cardPack, ref cardPack.cardIndex);
                player[0].DrawCards(cardPack, ref cardPack.cardIndex);
            }
            Thread.Sleep(2000);

            player[0].cards[0] = 10;
            player[0].cards[1] = 10;

            dealer.cards[0] = 1;
            dealer.cards[1] = 5;


            Console.Write("공개된 딜러의 카드 : ");
            dealer.PrintAllCards();
            Console.WriteLine();
            Console.Write("플레이어의 카드 : ");
            player[0].PrintAllCards();
            Console.WriteLine();

            while (true)
            {
                //플레이어 차례
                Console.WriteLine();              
                for (int i = 0; i < playerNumber; i++)
                {
                    // player[i]가 스테이하지 않았을때
                    if (!player[i].isStay)
                    {
                        int menu = 0;
                        Console.WriteLine("================================================");
                        Console.WriteLine("플레이어 차례({0}번째)", i + 1);
                        Console.WriteLine("================================================");
                        Console.WriteLine();
                        //스플릿 여부 결정
                        if (player[i].HasSameCard() && !player[i].checkSameCard)
                        {
                            player[i].checkSameCard = true;
                            do
                            {
                                Console.Write("스플릿(0), 스플릿 X(1) : ");
                                menu = int.Parse(Console.ReadLine());
                                Console.WriteLine();
                            } while (menu > 1);

                            if (menu == 0)
                            {
                                playerNumber++;
                                if (playerNumber <= 4)
                                {
                                    Console.WriteLine("카드를 다시 받습니다.");
                                    Console.WriteLine();
                                    player[i + 1].cards[0] = player[i].cards[1];
                                    player[i + 1].cardIndex++;
                                    player[i + 1].DrawCards(cardPack, ref cardPack.cardIndex);
                                    player[i].cards[1] = 0;
                                    player[i].cardIndex--;
                                    player[i].DrawCards(cardPack, ref cardPack.cardIndex);
                                    player[i].hasSameCard = false;
                                    Console.WriteLine();
                                    Console.Write("플레이어 카드({0}번째) : ", i + 1);
                                    player[i].PrintAllCards();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.Write("플레이어 카드({0}번째) : ", i + 2);
                                    player[i + 1].PrintAllCards();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                }
                                else
                                {
                                    playerNumber = 4;
                                    Console.WriteLine("더 이상 스플릿할 수 없습니다.");
                                }
                            }
                            else
                            {
                                player[i].hasSameCard = false;
                            }
                        }

                        Console.Write("플레이어 카드({0}번 카드) : ", i + 1);
                        player[i].PrintAllCards();
                        Console.WriteLine();
                        player[i].SumCards();

                        // 블랙잭 및 합 21 검사
                        if (player[i].cardSum == 21)
                        {
                            Console.WriteLine("플레이어의 {0}번 카드가 21 달성!", i + 1);                           

                            if (player[i].HasAce() && player[i].HasTen())
                            {
                                player[i].isBlackjack = true;
                                player[i].isStay = true;
                                Console.WriteLine("플레이어 {0}번 블랙잭", i + 1);
                            }
                            Console.WriteLine();
                            player[i].isStay = true;
                        }
                        else
                        {
                            // 메뉴를 입력받음
                            do
                            {
                                Console.WriteLine("플레이어 {0}번 카드의 합 : " + player[i].cardSum, i + 1);
                                Console.WriteLine();
                                Console.Write("히트(0), 스테이(1) : ");
                                menu = int.Parse(Console.ReadLine());
                            } while (menu > 1);
                            // 메뉴에 따른 행동
                            if (menu == 0)
                            {
                                player[i].DrawCards(cardPack, ref cardPack.cardIndex);
                            }
                            else
                            {
                                player[i].isStay = true;
                            }
                            // 플레이어 카드 출력 및 버스트 계산
                            Console.Write("플레이어 카드({0}번 카드) : ", i + 1);
                            player[i].PrintAllCards();
                            Console.WriteLine();
                            player[i].SumCards();
                            if (player[i].cardSum == 21)
                            {
                                Console.WriteLine("플레이어의 {0}번 카드가 21 달성!", i + 1);
                                Console.WriteLine();
                                player[i].isStay = true;
                            }
                            else if (player[i].IsBust())
                            {
                                Console.WriteLine("플레이어 {0}번 카드 합 : " + player[i].cardSum, i + 1);
                                Console.WriteLine("플레이어 {0}번 카드 버스트", i + 1);
                                player[i].isBust = true;
                                player[i].isStay = true;
                                playerBustCounter++;
                            }
                            else
                            {
                                Console.WriteLine("플레이어 {0}번 카드 합 : " + player[i].cardSum, i + 1);
                                Console.WriteLine();
                            }
                        }
                    }
                    Thread.Sleep(1000);
                }

                dealer.SumCards();

                // 플레이어의 카드가 전부 버스트가 아닐 때
                if (playerBustCounter < playerNumber && !isGameOver)
                {
                    // 딜러 차례
                    // 딜러가 스테이하지 않았을 때,
                    if (!dealer.isStay)
                    {
                        Console.WriteLine("================================================");
                        Console.WriteLine("딜러 차례");
                        Console.WriteLine("================================================");
                        Thread.Sleep(2000);
                        // 블랙잭 검사
                        if (dealer.cardSum == 21)
                        {
                            if (dealer.HasAce() && dealer.HasTen())
                            {
                                dealer.isBlackjack = true;
                            }
                            Console.WriteLine("딜러 : 스테이");
                            dealer.isStay = true;
                        }
                        else if (dealer.cardSum < 17)
                        {
                            Console.WriteLine("딜러 : 히트");
                            dealer.DrawCards(cardPack, ref cardPack.cardIndex);
                        }
                        else if (dealer.cardSum >= 17)
                        {
                            Console.WriteLine("딜러 : 스테이");
                            dealer.isStay = true;
                        }

                        //딜러 카드 공개
                        Console.WriteLine();
                        Console.Write("공개된 딜러의 카드 : ");
                        dealer.PrintAllCards();
                        Console.WriteLine();
                        dealer.SumCards();

                        if (dealer.IsBust())
                        {
                            Console.WriteLine("딜러 버스트");
                            Console.WriteLine();
                            dealer.isStay = true;
                            isGameOver = true;
                        }
                    }
                }
                else
                {
                    isGameOver = true;
                }

                int playerStayCounter = 0;

                // 플레이어 스테이 카운트
                for (int i = 0; i < playerNumber; i++)
                {
                    if (player[i].isStay) playerStayCounter++;
                }

                // 전부 스테이이거나 게임 오버이거나
                if (playerStayCounter == playerNumber && dealer.isStay || isGameOver)
                {
                    int i = 0;
                    int drawCount = 0;
                    int dealerWinCount = 0;
                    int playerWinCount = 0;

                    for (i = 0; i < playerNumber; i++)
                    {
                        if (player[i].isBlackjack)
                        {
                            if (dealer.isBlackjack)
                            {
                                Console.WriteLine("딜러 블랙잭");
                                Console.WriteLine();
                                drawCount++;
                            }
                            else
                            {
                                playerWinCount++;
                            }
                        }
                        else
                        {
                            if (dealer.isBlackjack)
                            {
                                Console.WriteLine("딜러 블랙잭");
                                Console.WriteLine();
                                dealerWinCount++;
                                break;
                            }

                            if (!player[i].isBust)
                            {
                                if (dealer.isBust)
                                {
                                    playerWinCount++;
                                    break;
                                }
                                if (player[i].cardSum > dealer.cardSum)
                                {
                                    playerWinCount++;
                                    break;
                                }
                                else if (player[i].cardSum == dealer.cardSum)
                                {
                                    drawCount++;
                                    dealerWinCount++;
                                }
                                else
                                {
                                    dealerWinCount++;
                                }
                            }
                            else
                            {
                                dealerWinCount++;
                            }
                        }
                    }

                    // 최종 승리 판정
                    Console.WriteLine();
                    Console.WriteLine("=====================최종결과=====================");

                    if (playerWinCount >= 1)
                    {
                        Console.WriteLine("플레이어 승리");
                        break;
                    }
                    if (drawCount == playerNumber)
                    {
                        Console.WriteLine("무승부");
                        break;
                    }
                    if(dealerWinCount == playerNumber)
                    {
                        Console.WriteLine("딜러 승리");
                        break;
                    }
                    Console.WriteLine();
                }
            }

            // 최종 결과 출력        
            Console.WriteLine();
            Console.Write("딜러의 카드 : ");
            dealer.PrintCard(dealer.cards[0]);
            Console.Write(", ");
            dealer.PrintAllCards();
            Console.WriteLine();
            Console.WriteLine("딜러 카드 합 : " + dealer.cardSum);
            Console.WriteLine();
            for (int i = 0; i < playerNumber; i++)
            {
                Console.Write("플레이어의 {0}번 카드 : ", i + 1);
                player[i].PrintAllCards();
                Console.WriteLine();
                Console.WriteLine("플레이어의 {0}번 카드 합 : " + player[i].cardSum, i + 1);
            }
            Console.WriteLine();
        }
    }

    public class Card
    {
        public int[] cards;
        public bool isStay = false, hasAce = false, hasTen = false, isBlackjack = false, isBust = false;
        public int cardSum = 0, cardIndex = 0;
        public int aceCount = 0;

        public Card(int n)
        {
            Random rand = new Random();
            cards = new int[n];

            for (int i = 0; i < n; i++)
            {
                cards[i] = i + 1;
            }

            for (int i = 0; i < n; i++)
            {
                int k = rand.Next(n);
                int temp = cards[i];
                cards[i] = cards[k];
                cards[k] = temp;
            }
        }
        public Card() { cards = new int[20]; }

        public bool HasAce()
        {
            aceCount = 0;
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] % 13 == 1)
                {
                    hasAce = true;
                    aceCount++;
                }
            }
            return hasAce;
        }
        public bool HasTen()
        {
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] == 0) break;
                if (cards[i] % 13 == 0 || cards[i] % 13 >= 10)
                    hasTen = true;
            }
            return hasTen;
        }
        public void SumCards()
        {
            cardSum = 0;
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] != 0)
                {
                    int num = cards[i] % 13;
                    switch (num)
                    {
                        case 1:
                            num = 11;
                            break;
                        case 11:
                        case 12:
                        case 0:
                            num = 10;
                            break;
                        default:
                            break;
                    }
                    cardSum += num;
                }
            }

            // 21 밑이 될 때까지 최대 ace의 갯수만큼 10을 차감
            if (cardSum > 21 && HasAce())
            {
                for(int i = 0; i < aceCount; i++)
                {
                    cardSum -= 10;                    
                    if (cardSum <= 21) break;
                }
            }
            
        }
        public void PrintAllCards()
        {
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] == 0) break;

                PrintCard(cards[i]);
                Console.Write(", ");
            }
        }
        public void PrintCard(int card)
        {
            if ((card - 1) / 13 == 0)
            {
                Console.Write("♤");
                if (card % 13 == 1)
                    Console.Write("A");
                else if (card % 13 == 11)
                    Console.Write("J");
                else if (card % 13 == 12)
                    Console.Write("Q");
                else if (card % 13 == 0)
                    Console.Write("K");
                else
                    Console.Write("{0}", card % 13);
            }
            else if ((card - 1) / 13 == 1)
            {
                Console.Write("◇");

                if (card % 13 == 1)
                    Console.Write("A");
                else if (card % 13 == 11)
                    Console.Write("J");
                else if (card % 13 == 12)
                    Console.Write("Q");
                else if (card % 13 == 0)
                    Console.Write("K");
                else
                    Console.Write("{0}", card % 13);
            }
            else if ((card - 1) / 13 == 2)
            {
                Console.Write("♡");
                if (card % 13 == 1)
                    Console.Write("A");
                else if (card % 13 == 11)
                    Console.Write("J");
                else if (card % 13 == 12)
                    Console.Write("Q");
                else if (card % 13 == 0)
                    Console.Write("K");
                else
                    Console.Write("{0}", card % 13);
            }
            else if ((card - 1) / 13 == 3)
            {
                Console.Write("♧");
                if (card % 13 == 1)
                    Console.Write("A");
                else if (card % 13 == 11)
                    Console.Write("J");
                else if (card % 13 == 12)
                    Console.Write("Q");
                else if (card % 13 == 0)
                    Console.Write("K");
                else
                    Console.Write("{0}", card % 13);
            }
        }
        public void DrawCards(Card cardPack, ref int index)
        {
            cards[cardIndex] = cardPack.cards[index];
            cardIndex++;
            index++;
        }
        public bool IsBust()
        {
            SumCards();
            if (cardSum > 21) isBust = true;
            return isBust;
        }
    }

    public class Dealer : Card
    {
        public new void PrintAllCards()
        {
            for (int i = 1; i < cards.Length; i++)
            {
                if (cards[i] == 0) break;
                PrintCard(cards[i]);
                Console.Write(", ");
            }
        }
    }

    public class Player : Card
    {
        public bool hasSameCard = false, checkSameCard = false;

        public bool HasSameCard()
        {
            if ((cards[0] % 13).Equals(cards[1] % 13)) hasSameCard = true;

            return hasSameCard;
        }
    }
}
