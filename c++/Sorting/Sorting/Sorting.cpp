#include <iostream>
#include <list>
#include <fstream>
#include <iomanip>
#include <algorithm>
#include <string>

using namespace std;

class isEqualSum {
public:
    bool operator() (string s1, string s2)
    {
        int sum1 = countNumbers(s1), sum2 = countNumbers(s2);
        int length = s1.length() > s2.length() ? s1.length() : s2.length();
        return (sum1 == sum2);
    }
private:
    int countNumbers(string s)
    {
        int sum = 0;
        for (int i = 0; i < s.length(); i++)
        {
            if ((int)s[i] > 47 && (int)s[i] < 58)
                sum++;
        }
        return sum;
    }
};

int main()
{
    ifstream fin("input.txt");
    ofstream fout("output.txt");
    if (!fin.is_open())
        fout << "Error! Cannot open file!\n";
    else if (fin.peek() == EOF)
        fout << "Empty file!\n";
    else
    {
        list<string> s;
        string str;
        try
        {
            while (fin >> str) {
                if (str.size() <= 100)
                    s.push_back(str);
                else
                    throw exception();
            }
        }
        catch (...)
        {
            fout << "Incorrect input!" << endl;
        }
        isEqualSum b;
        list<string>::iterator it = s.begin();
        list<string>::iterator it1 = s.begin();
        it1++;
        while (it1 != s.end()) {
            if (b(*it, *it1)) {
                s.erase(it1);
                it1 = it;
                it1++;
                continue;
            }
            it++;
            it1++;
        }
        for (auto& x : s) {
            fout << x << endl;
        }
    }
}

