using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FightManager.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommonButton : ContentView
    {
        public static readonly BindableProperty _BorderColorProperty = BindableProperty.Create(
            nameof(_BorderColor), typeof(Color), typeof(CommonButton), Color.LightGray);

        public static readonly BindableProperty _MainColorProperty = BindableProperty.Create(
            nameof(_MainColor), typeof(Color), typeof(CommonButton), Color.DarkGray);

        public static readonly BindableProperty _MainColorTappedProperty = BindableProperty.Create(
            nameof(_MainColorTapped), typeof(Color), typeof(CommonButton), Color.Gray);

        public static readonly BindableProperty _BorderColorTapppedProperty = BindableProperty.Create(
            nameof(_BorderColorTappped), typeof(Color), typeof(CommonButton), Color.White);

        public static readonly BindableProperty _TextProperty = BindableProperty.Create(
            nameof(_Text), typeof(string), typeof(CommonButton), "Кнопка");

        public static readonly BindableProperty _TextColorProperty = BindableProperty.Create(
            nameof(_TextColor), typeof(Color), typeof(CommonButton), Color.Black);

        public static readonly BindableProperty _TextColorTappedProperty = BindableProperty.Create(
            nameof(_TextColorTapped), typeof(Color), typeof(CommonButton), Color.DarkGray);

        public static readonly BindableProperty _FontSizeProperty = BindableProperty.Create(
            nameof(_FontSize), typeof(int), typeof(CommonButton), 14);

        public static readonly BindableProperty _FontFamilyProperty = BindableProperty.Create(
            nameof(_FontFamily), typeof(string), typeof(CommonButton), "Arial");

        public static readonly BindableProperty _TapCommandProperty = BindableProperty.Create(
            nameof(_TapCommand), typeof(Command), typeof(CommonButton), null);

        public static readonly BindableProperty _LongTapCommandProperty = BindableProperty.Create(
            nameof(_LongTapCommand), typeof(Command), typeof(CommonButton), null);

        public static readonly BindableProperty _TapCommandParameterProperty = BindableProperty.Create(
            nameof(_TapCommandParameter), typeof(object), typeof(CommonButton), null);

        public static readonly BindableProperty _LongTapCommandParameterProperty = BindableProperty.Create(
            nameof(_LongTapCommandParameter), typeof(object), typeof(CommonButton), null);
        public object _LongTapCommandParameter
        {
            get => (object)GetValue(CommonButton._LongTapCommandParameterProperty);
            set => SetValue(CommonButton._LongTapCommandParameterProperty, value);
        }
        public object _TapCommandParameter
        {
            get => (object)GetValue(CommonButton._TapCommandParameterProperty);
            set => SetValue(CommonButton._TapCommandParameterProperty, value);
        }
        public Command _LongTapCommand
        {
            get
            {
                return (Command)GetValue(CommonButton._LongTapCommandProperty);
            }
            set => SetValue(CommonButton._LongTapCommandProperty, value);
        }
        public Command _TapCommand
        {
            get
            {
                return (Command)GetValue(CommonButton._TapCommandProperty);
            }
            set => SetValue(CommonButton._TapCommandProperty, value);
        }
        public string _FontFamily
        {
            get => (string)GetValue(CommonButton._FontFamilyProperty);
            set => SetValue(CommonButton._FontFamilyProperty, value);
        }
        public int _FontSize
        {
            get => (int)GetValue(CommonButton._FontSizeProperty);
            set => SetValue(CommonButton._FontSizeProperty, value);
        }
        public Color _TextColorTapped
        {
            get => (Color)GetValue(CommonButton._TextColorTappedProperty);
            set => SetValue(CommonButton._TextColorTappedProperty, value);
        }
        public Color _TextColor
        {
            get => (Color)GetValue(CommonButton._TextColorProperty);
            set => SetValue(CommonButton._TextColorProperty, value);
        }
        public string _Text
        {
            get => (string)GetValue(CommonButton._TextProperty);
            set => SetValue(CommonButton._TextProperty, value);
        }
        public Color _BorderColorTappped
        {
            get => (Color)GetValue(CommonButton._BorderColorTapppedProperty);
            set => SetValue(CommonButton._BorderColorTapppedProperty, value);
        }
        public Color _MainColorTapped
        {
            get => (Color)GetValue(CommonButton._MainColorTappedProperty);
            set => SetValue(CommonButton._MainColorTappedProperty, value);
        }
        public Color _MainColor
        {
            get => (Color)GetValue(CommonButton._MainColorProperty);
            set => SetValue(CommonButton._MainColorProperty, value);
        }
        public Color _BorderColor
        {
            get => (Color)GetValue(CommonButton._BorderColorProperty);
            set => SetValue(CommonButton._BorderColorProperty, value);
        }

        public CommonButton()
        {
            InitializeComponent();
        }
    }
}