// Game.h
#include<iostream>
#include<string>

using namespace std;

class Game
{
public:
	Game();
	~Game();
	int numPiles;
	int rocksInPile[9];
	bool turn;
	string inputCommand;
	// tcpPacket will either be in "mnn", "CSome comment" (80 bytes max),  or "F"
	string tcpPacket;
	// boardConfig will be received as a packet (on the client machine) in “mn1n1n2n2n3n3nmnm” format
	// This information will be used to create the gameboard
	string boardConfig;
	void parseBoardConfig();
	bool determineTurn();
	void displayErrorMessage();
	void displayGameBoard();
	void checkForWinner();
	void getCommand();
	void checkCommand(string);
private:
	int pileToRemove;
	int numberToRemove;
};
