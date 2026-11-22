using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using GameTemplateMAUI.Sessions;
using System.Collections.ObjectModel;
using TwoKnightsGame;
using TwoKnightsGame.Figures;

namespace GameTemplateMAUI.ViewModels;

public partial class GameViewModel : ObservableObject
{
    private readonly ISession _session;

    [ObservableProperty]
    private GameState state = null!;
    [ObservableProperty]
    private int size;
    [ObservableProperty]
    private IFigure? selectedFigure;
    [ObservableProperty]
    private bool isGameEnded;

    public ObservableCollection<BoardCellViewModel> Cells { get; } = new();

    public GameViewModel(ISession session)
    {
        _session = session;

        State = _session.State;

        IsGameEnded = false;        

        UpdateBoard();

        _session.StateChanged += OnStateChanged;
        _session.GameEnded += OnGameEnded;
    }

    private void OnGameEnded(object? sender, GameState finalState)
    {
        IsGameEnded = true;
        WeakReferenceMessenger.Default.Send("game over");
    }
    private void OnStateChanged(object? sender, GameState newState)
    {
        State = newState;
        UpdateBoard();
    }
    
    private void UpdateBoard()
    {
        Cells.Clear();

        Board board = State.Board;
        Size = board.size;

        // y = row, x = column
        for (int y = 0; y < board.size; y++)
        {
            for (int x = 0; x < board.size; x++)
            {
                object? occupant = board.boardGrid[x, y];

                string text = "";

                if (ReferenceEquals(occupant, board.KnightA))
                    text = "A";
                else if (ReferenceEquals(occupant, board.KnightB))
                    text = "B";
                else if (board.winningSpot[0] == x &&
                         board.winningSpot[1] == y)
                    text = "W";

                Cells.Add(new BoardCellViewModel(x,y,text, board.winningSpot[0] == x &&
                        board.winningSpot[1] == y)
                );
            }
        }
    }

    
    private bool RequestMove(Move move)
    {
        bool accepted = _session.RequestMove(move);

        if (!accepted)
        {
            WeakReferenceMessenger.Default
                    .Send("move was not accepted.");
        }
        return accepted;
    }

    [RelayCommand]
    private void CellTapped(BoardCellViewModel cell)
    {
        object? occupant = State.Board.boardGrid[cell.X, cell.Y];

        // If the user clicked a knight, select it.
        if (occupant is IFigure figure)
        {
            SelectedFigure = figure;
            return;
        }

        // No knight selected yet.
        if (SelectedFigure is null)
            return;

        // The user clicked an empty destination cell.
        Move move = new Move(cell.X, cell.Y, SelectedFigure);

        bool accepted = RequestMove(move);

        if (accepted)
        {
            SelectedFigure = null;
        }
        
    }
}

