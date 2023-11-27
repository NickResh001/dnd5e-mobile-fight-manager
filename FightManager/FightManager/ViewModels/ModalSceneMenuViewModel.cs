using FightManager.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FightManager.ViewModels
{
    public class ModalSceneMenuViewModel : ViewModelBase
    {
		private DiceRoller diceRoller;
		public string DiceRollInput
		{
			get
			{
				return _diceRollInput;
			}
			set
			{
				_diceRollInput = value;
				OnPropertyChanged(nameof(DiceRollInput));
			}
		}
        private string _diceRollInput;
		public string DiceRollResult
		{
			get
			{
				return _diceRoolResult;
			}
			set
			{
				_diceRoolResult = value;
				OnPropertyChanged(nameof(DiceRollResult));
			}
		}
		private string _diceRoolResult;
        public bool Advantage
		{
			get
			{
				return _advantage;
			}
			set
			{
				_advantage = value;
				OnPropertyChanged(nameof(Advantage));
			}
		}
		private bool _advantage;
		public bool Disadvantage
		{
			get
			{
				return disadvantage;
			}
			set
			{
				disadvantage = value;
				OnPropertyChanged(nameof(Disadvantage));
			}
		}
        private bool disadvantage;

		public ICommand NavigateBackTo { get; }
		public ICommand RollCommand { get; }
        public ModalSceneMenuViewModel()
        {
			diceRoller = new DiceRoller();
			NavigateBackTo = new Command(() => { Navigation.PopModalAsync(); });
			RollCommand = new Command(RollDice);
        }

		public void RollDice()
		{
            DiceThrowInfo diceThrowInfo = diceRoller.Throw(DiceRollInput, Advantage, Disadvantage);

			switch (diceThrowInfo.status)
			{
				case DiceThrowStatus.Success:

					if (diceThrowInfo.advantage == diceThrowInfo.disadvantage)
						DiceRollResult = $"Результат: {diceThrowInfo.GetResult()}";
					else
					{
                        string res = "";
						string advSymb = "";
						res += $"Результат: ";

						if (diceThrowInfo.advantage)
							advSymb = "↑";
						else
                            advSymb = "↓";
                            
                        res += $"({diceThrowInfo.results[0]}, {diceThrowInfo.results[1]})";
						res += advSymb;
						res += $" {diceThrowInfo.GetResult()}";
						DiceRollResult = res;
                    }
                    break;
				case DiceThrowStatus.ExtraCharacters:
					DiceRollResult = "В формуле лишние символы";
					break;
				case DiceThrowStatus.FormulaErrors:
                    DiceRollResult = "В формуле есть ошибки";
                    break;
				case DiceThrowStatus.UndifinedError:
                    DiceRollResult = "Ошибка";
                    break;
				case DiceThrowStatus.EmptyInputString:
					DiceRollResult = "Строка формулы пуста";
					break;
				default:
					break;
			}
		}
    }
}