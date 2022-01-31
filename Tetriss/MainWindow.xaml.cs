using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Tetris;

namespace Tetriss
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly ImageSource[] tileImages = new ImageSource[] {


            new BitmapImage(new Uri("Assets/TileEmpty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileCyan.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileBlue.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileOrange.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileYellow.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileGreen.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TilePurple.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileRed.png", UriKind.Relative))

        };
        private readonly ImageSource[] blockImages = new ImageSource[] {

            new BitmapImage(new Uri("Assets/Block-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-I.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-J.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-L.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-O.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-S.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-T.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-Z.png", UriKind.Relative))

        };
        private readonly Image[,] imageControls;
        private GameState gameState = new GameState();

        private readonly int maxDelay = 1000;
        private readonly int minDelay = 75;
        private readonly int delayIncrease = 25;
        public MainWindow()
        {
            InitializeComponent();
            imageControls = SetupGameCanvas(gameState.GameGrid);
        }

        private Image[,] SetupGameCanvas(GameGrid gameGrid) {

            Image[,] imageControls = new Image[gameGrid.Rows, gameGrid.Columns];
            int cellSize = 25;
            for (int row = 0; row < gameGrid.Rows; row++) { 
            
                   for(int col = 0; col < gameGrid.Columns; col++)
                {
                    Image imageControl = new Image
                    {
                        Width = cellSize,
                        Height = cellSize

                    };
                Canvas.SetTop(imageControl, (row - 2) * cellSize + 10);
                Canvas.SetLeft(imageControl, col * cellSize);
                    GameCanvas.Children.Add(imageControl);
                    imageControls[row,col] = imageControl;
            }
            }
            return imageControls;
        }
        private void DrawGrid(GameGrid gameGrid)
        {

            for (int row = 0; row < gameGrid.Rows; row++)
            {

                for (int col = 0; col < gameGrid.Columns; col++)
                {
                    int id = gameGrid[row, col];
                    imageControls[row, col].Source = tileImages[id];

                }

            }
        }
        private void DrawBlock(Block block) {

            foreach (Position p in block.TilePositions())
            {
                
                imageControls[p.Row, p.Column].Source = tileImages[block.Id];
                
            }

        }

        private void DrawNextBlock(BlockQueue blockQueue) {

            Block next = blockQueue.NextBlock;
            NextImage.Source = blockImages[next.Id];        
        }
        private void DrawHeldBlock(Block heldBlock) {

            if (heldBlock == null) {

                HoldImage.Source = blockImages[0];
            }
            else
            {

                HoldImage.Source = blockImages[heldBlock.Id];
            }

        }

        private void Draw(GameState gameState) {
            DrawGrid(gameState.GameGrid);
            DrawBlock(gameState.CurrentBlock);
            DrawNextBlock(gameState.BlockQueue);
            DrawHeldBlock(gameState.HeldBlock);
            ScoreText.Text = "Score: " + gameState.score.ToString();
        }
        private async Task GameLoop() {

            Draw(gameState);
            while (!gameState.GameOver) {

                int delay = Math.Max(minDelay, maxDelay - (gameState.score * delayIncrease));
                await Task.Delay(delay);
                gameState.MoveBlockDown();
                Draw(gameState);
            }
            GameOverMenu.Visibility = Visibility.Visible;
            FinalScoreText.Text = "Score: " + gameState.score.ToString();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameState.GameOver) { return; }

            switch (e.Key) {

                case Key.Left:
                    gameState.MoveBlockLeft();
                    break;
                case Key.Right:
                    gameState.MoveBlockRight();
                    break;
                case Key.Down:
                    gameState.MoveBlockDown();
                    break;
                case Key.Up:
                    gameState.RotateBlockCW();
                    break;
                case Key.Z:
                    gameState.RotateBlockCCW();
                    break;
                case Key.Space:
                    gameState.MoveBlockDownFast();
                    break;
                case Key.C:
                    gameState.HoldBlock();
                    break;

            }
            Draw(gameState);
        }

        private async void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            await GameLoop();
        }

        private async void Play_Again_Click(object sender, RoutedEventArgs e)
        {
            gameState = new GameState();
            GameOverMenu.Visibility = Visibility.Hidden;
            await GameLoop();
        }
    }
}
