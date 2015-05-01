// Game.cpp

#include"Game.h"
#include<stdio.h>

Game::Game()
{
}

Game::~Game()
{
}

void Game::parseBoardConfig()
{
	int count = 0;
	string numHolder;

	numPiles = (boardConfig[0] - '0');
	for (int i = 1; i < boardConfig.length(); i += 2)
	{
		numHolder = boardConfig.substr(i, 2);
		rocksInPile[count] = stoi(numHolder);
		count++;
	}
}

bool Game::determineTurn()
{
	string inputCommand;

	if (turn == true)
	{
		getCommand();
	}
	else
	{
		// Wait to receive tcp packet
		// inputCommand = recv(s, buffer, MAX_RECV_BUF, 0);
		// checkCommand(inputCommand);
	}
}

void Game::displayErrorMessage()
{
	cout << endl;
	cout << "**************************" << endl;
	cout << "*  Invalid move, please  *" << endl;
	cout << "* choose a different one *" << endl;
	cout << "**************************" << endl;
	cout << endl;
	displayGameBoard();
}

void Game::displayGameBoard()
{
	cout << endl;
	cout << "                                   ~ NIM GAME ~                                 ";
	cout << "--------------------------------------------------------------------------------";
	for (int i = 0; i < numPiles; i++)
	{
		cout << i + 1 << ") ";
		for (int j = 0; j < rocksInPile[i]; j++)
		{
			cout << "@";
		}
		cout << endl;
	}
	cout << "--------------------------------------------------------------------------------";
	cout << endl;
}

void Game::checkForWinner()
{
	bool checkWinner = true;

	for (int i = 0; i < numPiles; i++)
	{
		if (rocksInPile[i] > 0)
		{
			checkWinner = false;
		}
	}

	if ((checkWinner == true) && (turn == true))
	{
		cout << "YOU WIN!!!" << endl;
		// Connection will be cut off at this point, other user will be informed that they lost.
		// End program
	}
	else if ((checkWinner == true) && (turn == false))
	{
		cout << "You lose..." << endl;
		// Close tcp connection, end program
	}
}

void Game::getCommand()
{
	cout << "Enter a command: ";
	getline(cin, inputCommand);
	system("cls");
	checkCommand(inputCommand);
}

void Game::checkCommand(string inputCommand)
{
	// "mnn" format
	if (((inputCommand[0] - '0') < 10))
	{
		if ((((inputCommand[1] - '0') < 2) && ((inputCommand[2] - '0') > 0) && (inputCommand[2] - '0') < 10) || (((inputCommand[1] - '0') == 2) && ((inputCommand[2] - '0') == 0)))
		{
			pileToRemove = (inputCommand[0] - '0');
			numberToRemove = stoi(inputCommand.substr(1, 2));
			if (rocksInPile[pileToRemove - 1] <= 0)
			{
				displayErrorMessage();
			}
			rocksInPile[pileToRemove - 1] -= numberToRemove;
			checkForWinner();
			displayGameBoard();
			// Input is good, send inputCommand to other player
			// Flip turn and then redetermine turn
			turn = !turn;
			determineTurn();
		}
		else
		{
			// Your turn, it's okay to put in incorrect input
			if (turn == true)
			{
				displayErrorMessage();
				getCommand();
			}
			// Their turn, if it's wrong then they lose!
			else
			{
				cout << "YOU WIN!!!";
				// Close tcp connection and end game
			}
		}
	}
	// "Ccomment" format
	else if (inputCommand[0] == 'C')
	{
		// Send this comment (inputCommand) to other user
		cout << inputCommand.substr(1, 80) << endl;
		displayGameBoard();
		getCommand();
	}
	//"F" format
	else if (inputCommand[0] == 'F')
	{
		if (turn == true)
		{
			cout << "You lose..." << endl;
			// Send 'F' to other user
			// Close tcp connection and end game
		}
		else
		{
			cout << "YOU WIN!!!";
			// Close tcp connection and end game
		}
	}
	else
	{
		// Your turn, it's okay to put in incorrect input
		if (turn == true)
		{
			displayErrorMessage();
			getCommand();
		}
		// Their turn, if it's wrong then they lose!
		else
		{
			cout << "YOU WIN!!!";
			// Close tcp connection and end game
		}
	}
}
