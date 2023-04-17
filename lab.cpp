//Programmer's Name: Jia le
//Program's Purpose: array and file reading with structure
//LAB 
#include <iostream>
#include <fstream>
#include <iomanip>
#define MAX_no 10
using namespace std;

struct info{
	string log;
	string pass;
	int num;
};

void get_info(string&,string&);
void compare_info(ifstream&,int&,string&,string&,info[]);

int main()
{

	string user_log,user_pass;
	info user[MAX_no];
	int x;
	ifstream fin ("login2.txt");
	
	get_info(user_log,user_pass);
	compare_info(fin,x,user_log,user_pass,user);
	
}

void get_info(string& user_log,string& user_pass)
{
	cout<<"LOGIN: "<<endl;
	cin>>user_log;
	cout<<"PASSWORD: "<<endl;
	cin>>user_pass;
	cout<<"Entered login and password are: "<<user_log<<"\t"<<user_pass<<endl;
}

void compare_info(ifstream& fin,int& x,string& user_log,string& user_pass, info user[])
{
	for(x=0;!fin.eof();x++)
	{
		fin>>user[x].log>>user[x].pass>>user[x].num;
		cout<<"\t"<<user[x].log<<"\t"<<user[x].pass<<"---> ";
		if (user_log==user[x].log&&user_pass==user[x].pass)
		{
			cout<<"Match found. Search stops!"<<endl;
			cout<<"\tComparison attempt number: "<<x+1<<endl;
			cout<<"Successful match result :"<<endl;
			cout<<"Login: "<<user[x].log<<endl;
			cout<<"Password: "<<user[x].pass<<endl;
			cout<<"User ID: "<<user[x].num<<endl;
			
			for(x=x+1;!fin.eof();x++)
			{
				fin>>user[x].log>>user[x].pass>>user[x].num;
			}
			break;
		}
		else 
		{
			cout<<"Match NOT found. Keep searching"<<endl;
		}
	}
	
	cout<<"User"<<setw(23)<<"Login"<<setw(20)<<"Password"<<setw(30)<<"ID"<<endl;
	cout<<"------------------------------------------------------------------------"<<endl;
	for(x=0;x<10;x++)
	{
		cout<<"User #"<<x+1<<setw(20)<<user[x].log<<setw(20)<<user[x].pass<<setw(30)<<user[x].num<<endl;
	}
	
	fin.close();
}





























