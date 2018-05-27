using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BlackJack
{
    class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            int[] card = new int[52];//카드 패
            int[] dealerCard = new int[20];
            int[] playerCard = new int[20];
            int dealerCount = 0, playerCount = 0, totalCount = 0;  // 각각 현재 카드의 위치(배열 인덱스)
            bool dealerStay = false, playerStay = false;
            bool dealerBlackjack = false, playerBlackjack = false;
            int dealerSum = 0, playerSum = 0;

            for (int i = 0; i < 52; i++)
            {
                card[i] = i + 1;
            }
            Console.WriteLine("게임을 시작합니다.");
            Thread.Sleep(1000);

            Console.WriteLine();
            Console.WriteLine("카드를 섞는 중입니다...");

            // 카드 섞기
            Sort(ref card);
            Thread.Sleep(1000);

            Console.WriteLine();
            Console.WriteLine("카드를 2장씩 받습니다.");

            // 게임 시작
            for (int i = 0; i < 2; i++) {
                dealerCard[dealerCount] = DrawCard(card, ref totalCount);
                playerCard[playerCount] = DrawCard(card, ref totalCount);
                dealerCount++;
                playerCount++;
            }

            Thread.Sleep(1000);

            Console.Write("딜러의 카드 : ");
            DealerCardPrint(dealerCard);          
            PlayerCardPrint(playerCard);

            // 턴 순환
            while (true)
            {
                //카드 합 계산
                dealerSum = SumCardnumbers(dealerCard);
                playerSum = SumCardnumbers(playerCard);
                Console.WriteLine("==========================================");
                //딜러가 스테이 하지 않았을 경우
                if(!dealerStay)                  
                {
                    Console.WriteLine();
                    Console.WriteLine("딜러 차례");
                    Thread.Sleep(2000);
                    // 딜러 버스트일 때, 에이스가 존재하면 1로 계산
                    if (dealerSum > 21)
                    {
                        if (HasAce(dealerCard)) dealerSum -= 10;
                    }
                    // 카드 합계에 따른 딜러의 행동 계산
                    if (dealerSum < 17)
                    {
                        Console.WriteLine("딜러 : 히트");
                        dealerCard[dealerCount] = DrawCard(card, ref totalCount);
                        dealerCount++;
                    }
                    else if (dealerSum == 21)
                    {
                        if (HasAce(dealerCard) && HasTen(dealerCard))
                        {
                            dealerBlackjack = true;
                            dealerStay = true;   
                        }
                    }
                    else
                    {
                        Console.WriteLine("딜러 : 스테이");
                        dealerStay = true;
                    }
                }
                if (!dealerBlackjack)
                {
                    //딜러 카드 공개
                    Console.WriteLine();
                    Console.Write("공개된 딜러의 카드 : ");
                    DealerCardPrint(dealerCard);
                    Console.WriteLine();
                }
                dealerSum = SumCardnumbers(dealerCard);

                // 딜러가 카드를 뽑았을 때 버스트이면,
                if (dealerSum > 21)
                {
                    // 에이스가 존재할 때 에이스를 1로 계산함
                    if (HasAce(dealerCard)) dealerSum -= 10;
                    // 그래도 버스트라면 플레이어의 승리로 게임 종료
                    if (dealerSum > 21)
                    {
                        Console.WriteLine("딜러 버스트");
                        Console.WriteLine("플레이어 승리");
                        break;
                    }
                }
                // 카드의 합이 21이면서 에이스와 10을 가지고 있으면 블랙잭
                else if (dealerSum == 21)
                {
                    if (HasAce(dealerCard) && HasTen(dealerCard))
                    {
                        Console.WriteLine();
                        Console.WriteLine("딜러 블랙잭");
                        dealerBlackjack = true;
                        dealerStay = true;
                        Console.Write("딜러의 카드 : ");
                        PrintCard(dealerCard[0]);
                        Console.Write(", ");
                        DealerCardPrint(dealerCard);
                    }
                }

                // 플레이어가 스테이하지 않았을 경우 플레이어 차례
                if (!playerStay)
                {
                    Console.WriteLine();
                    Console.WriteLine("플레이어 차례");
                    if (playerSum == 21)
                    {
                        if (HasAce(playerCard) && HasTen(playerCard))
                        {
                            Console.WriteLine();
                            Console.WriteLine("플레이어 블랙잭");
                            Console.WriteLine();
                            playerBlackjack = true;
                            playerStay = true;

                            if (playerBlackjack)
                            {
                                if (dealerBlackjack)
                                {
                                    Console.WriteLine("무승부");
                                }
                                else
                                {
                                    Console.WriteLine("플레이어 승리");
                                }
                                break;
                            }
                            else
                            {
                                if (dealerBlackjack)
                                {
                                    Console.WriteLine("딜러 승리");
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    
                    int menu;
                    // 메뉴를 입력받음
                    do
                    {
                        Console.Write("히트(0), 스테이(1) : ");
                        menu = int.Parse(Console.ReadLine());
                    } while (menu > 1);

                    // 메뉴에 따른 행동 결정
                    switch (menu)
                    {
                        case 0:
                            playerCard[playerCount] = DrawCard(card, ref totalCount);
                            playerCount++;
                            break;
                        case 1:
                            playerStay = true;
                            break;
                    }
                }

                PlayerCardPrint(playerCard);
                Console.WriteLine();                
                //플레이어 카드 합 계산 및 출력
                playerSum = SumCardnumbers(playerCard);

                // 플레이어가 버스트일 때, 에이스가 있으면 에이스를 1로 계산
                if (playerSum > 21)
                {
                    if (HasAce(playerCard)) playerSum -= 10;
                    // 그래도 버스트라면 딜러의 승리로 게임 종료
                    if (playerSum > 21)
                    {
                        Console.WriteLine("플레이어 버스트");
                        Console.WriteLine("딜러 승리");
                        break;
                    }
                }
                // 카드의 합이 21이면서 에이스와 10을 가지고 있으면 블랙잭
                else if (playerSum == 21)
                {
                    if (HasAce(playerCard) && HasTen(playerCard))
                    {
                        Console.WriteLine("플레이어 블랙잭");
                        playerBlackjack = true;
                    }
                }
                Console.WriteLine("플레이어 카드 합 : " + playerSum);
                Console.WriteLine();

                

                // 플레이어와 딜러 모두 스테이 했을 때 점수 비교
                if (playerStay && dealerStay)
                {
                    if(playerSum > dealerSum)
                    {
                        Console.WriteLine("플레이어 승리");
                    }
                    else if(playerSum == dealerSum)
                    {
                        Console.WriteLine("무승부");
                    }
                    else
                    {
                        Console.WriteLine("딜러 승리");
                    }
                    break;
                }
            }
            // 결과 출력
            Console.WriteLine();
            Console.WriteLine("=====================결과=====================");
            Console.WriteLine();
            Console.Write("딜러의 카드 : ");
            PrintCard(dealerCard[0]);
            Console.Write(", ");
            DealerCardPrint(dealerCard);
            dealerSum = SumCardnumbers(dealerCard);
            // 점수가 21 이상일 때 에이스 계산
            if (dealerSum > 21)
            {
                if (HasAce(dealerCard)) dealerSum -= 10;
            }
            Console.WriteLine("딜러 카드 합 : " + dealerSum);
            Console.WriteLine();
            Console.Write("플레이어의 카드 : ");
            PlayerCardPrint(playerCard);
            playerSum = SumCardnumbers(playerCard);
            // 점수가 21 이상일 때 에이스 계산
            if (playerSum > 21)
            {
                if (HasAce(playerCard)) playerSum -= 10;
            }
            Console.WriteLine("플레이어 카드 합 : " + playerSum);
        }
        
        static bool HasAce(int[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] % 13 == 1)
                {
                    return true;
                }
            }
            return false;
        }
        static bool HasTen(int[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] % 13 >= 10 || cards[i] % 13 == 0)
                {
                    return true;
                }
            }
            return false;
        }
        static int SumCardnumbers(int[] cards)
        {
            int cardsSum = 0;
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
                    cardsSum += num;
                }
            }
            return cardsSum;
        }
        static void DealerCardPrint(int[] dealers)
        {           
            for (int i = 1; i < dealers.Length; i++)
            {
                if (dealers[i] == 0) break;
                if (dealers[i] != 0)
                {
                    PrintCard(dealers[i]);
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }
        static void PlayerCardPrint(int[] players)
        {
            Console.Write("플레이어의 카드 : ");
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i] == 0) break;
                if (players[i] != 0)
                {
                    PrintCard(players[i]);
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }
        static void Sort(ref int[] cards)
        {
            for(int i = 0; i < 52; i++)
            {
                int k = rand.Next(52);
                int temp = cards[i];
                cards[i] = cards[k];
                cards[k] = temp;
            }
        }
        static void PrintCard(int card)
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
        static int DrawCard(int[] cards, ref int count)
        {
            int card = cards[count];
            count = count + 1;
            return card;
        }
    }
}
