#include <iostream>
#include <ctime>
#define MAX_no 1000
using namespace std;

void get_choice(char&);
void check_in(time_t[], int&);
void display_serial (int&);
void check_out(time_t[], time_t, int, int&, int);
void switch_variable(int&,int&,int&);
void calc_fee(int);

int main()
{
	int serial,diff; //declare variable for calculate time difference
	char choice; //declare variable for user choice to check in or check out car
	time_t in[MAX_no], out; //declare variable for check in and check out time
	int i=0;//delcare i and j for count

	while(true)//create loop for program to run forever
	{	
		get_choice(choice); //get user choice to check in or check out
		
		if (choice=='a')
		{
			check_in(in,i); //check in car
		}		
		
		if (choice=='b')
		{
			check_out(in, out, diff,i,serial); //check out car
		}
		
		system("pause");
		system("cls");
	}
}

void get_choice (char& choice)
{
	cout<<"*    *   *****   *       *       *****    *   		"<<endl;
	cout<<"*    *   *       *       *       *   *	  *			"<<endl;
	cout<<"******   *****   *       *       *   *    *    		"<<endl;
	cout<<"*    *   *       *       *       *   *             	"<<endl;
	cout<<"*    *   *****   *****   *****   *****    *         	"<<endl;
	cout<<"Welcome to Queensbay Mall!!!"<<endl;
	cout<<"Enter 'a' to check in, 'b' to check out"<<endl; //get user choice to check in or check out 
	cin>>choice;
}

void check_in(time_t in[], int& i)
{
	display_serial (i); //give user serial number
	in[i]=time(0); //get check in time
	char* dti=ctime(&in[i]); //convert data type to display
	cout<<"Check in time: "<<dti; //display check in time
	i++; //increase count i for next user to get different serial number
}

void check_out(time_t in[],time_t out, int diff,int& i,int serial)
{
	cout<<"Enter serial"<<endl; //get car serial
	cin>>serial; //we ask user to enter serial instead of i so that i wont be changed
	
	int x;//declare x to be used in switching i and serial
	switch_variable(x, i, serial); //exchange serial with i to read in[i]

	char* dti=ctime(&in[i]); //convert data type so that can display
	cout<<"Check in time: "<<dti; //display check in time
	
	out=time(0); //get check out time
	char*dto=ctime(&out); //convert data type to char for display
	cout<<"Check out time: "<<dto; //display check out time
	diff=difftime(out,in[i]); //calculate duration car parked in seconds
	calc_fee(diff);// calculate and display parking fee
	
	switch_variable(x, i, serial);	 //switch back i with serial
}

void display_serial (int& i)
{
	if(i<10)
	{
		cout<<"Your serial number is 00"<<i<<endl;
	}
	else if((i>=10)&&(i<100))
	{
		cout<<"Your serial number is 0"<<i<<endl;
	}
	else if((i>=100)&&(i<1000))
	{
		cout<<"Your serial number is "<<i<<endl;
	}
	else if(i>=MAX_no)
	{
		cout<<"Your serial number is 000"; //renew serial number
		i=0;
	}
}

void calc_fee(int diff)
{
	cout<<"Parking fees :"<<endl;//display parking rate price
	cout<<"------------------------------------------"<<endl;
	cout<<"First 6 hours    : $ 5 per hour"<<endl;
	cout<<"Hours 7-12       : $ 3 per hour"<<endl;
	cout<<"Hours 13 onwards : $ 2 per hour"<<endl;
	cout<<"------------------------------------------"<<endl;
	
	int hours_parked = diff/3600; //covert duration parked from seconds to hours
	cout<<"You've parked for "<<hours_parked<<" hours"<<endl;
	
	int fee;//calculate parking fee
	if(hours_parked<=6)
	{
		fee=hours_parked*5;
	}
	else if((hours_parked>6)&&(hours_parked<=12))
	{
		fee= 30 + (hours_parked-6)*3;
	}
	else if(hours_parked>12)
	{
		fee= 30 + 18 + (hours_parked-12)*2;
	}
	cout<<"Parking fee: $"<<fee<<endl;
}

void switch_variable(int& x,int& i,int& serial)//exchange variable i and serial
{
	x=i; 
	i=serial;
	serial=x;
}






