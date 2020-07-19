// �������� ����������, ������� ���������� ���������� ������������� ����� �� 1 �� 100.
// ��� ������� � ������������ ������������ ���� ���������.
// ����� ����, ��� ����� ��������, ���������� ������� ���������� �������, ��������������� ��� �����,
// � ������������ ������������ ����������� ������� ��� ���, �� �������� ���������.
// ���� ��������� ������� �������� �������� � �������� � ������������ � ���������� ���������.

#include <Windows.h>
#include <cmath>

INT WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPSTR IpszCmdLine, int nCmdShow)
{
    wchar_t szTitle[] = L"���������� �����";
    wchar_t szNumQuery[] = L"��������� ����� �� 1 �� 100!";
    wchar_t szEqualQuery[] = L"���������� ����� ������ ��� ����� %d?";
    wchar_t szFound[] = L"���� �������� ����� %d �� %d �������.\n���������?";
    wchar_t sBuf[64];
    
    while (true) {
        int Min = 1, Max = 100;
        if (IDOK == MessageBox(0, szNumQuery, szTitle, MB_OKCANCEL | MB_ICONQUESTION))
        {
            int Guess = (Min + Max) / 2, Count = (int)ceil(log2(Max - Min));
            for (int i = 0; i < Count; ++i)
            {
                wsprintf(sBuf, szEqualQuery, Guess);
                if (IDYES == MessageBox(0, sBuf, szTitle, MB_YESNO | MB_ICONQUESTION))
                    Max = Guess;
                else
                    Min = Guess + 1;
                Guess = (Min + Max) / 2;

                if (Max == Min)
                {
                    wsprintf(sBuf, szFound, Guess, i + 1);
                    if (IDNO == MessageBox(0, sBuf, szTitle, MB_YESNO | MB_ICONINFORMATION))
                        return 0;
                }
            }
        }
        else
            return 0;
    }
    return 0;
}