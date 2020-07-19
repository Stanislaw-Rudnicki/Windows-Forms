// �������� ����������, ����������� ������� �� ����� ������� ������
// � ������� ������������������ ���� ��������� (���������� ���� ��������� � �� ����� ���).
// �� ��������� ���������� ���� ��������� ������ ������������
// ������� ����� �������� �� �������� (����� ����� �������� � ������ �������� �� ���������� ���� ���������).

#include <Windows.h>
#include <vector>
#include <string>
#include <sstream>
#include <iomanip>

using namespace std;

INT WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance,
    LPSTR lpCmdLine, INT nState) {

    vector<LPCWSTR> mes = {
        L"���� ����� ��������� ���������.",
        L"� ����� � �������� ���.",
        L"� ����� ����� ��� �������." };
    
    int i = 0, count = 0;
    wstring Caption = L"������� 1";
    wostringstream ss;

    while (i < mes.size()) {
        count += wcslen(mes[i]);
        if (IDCANCEL == MessageBox(0, mes[i++], Caption.c_str(),
            MB_OKCANCEL | MB_ICONINFORMATION | MB_DEFBUTTON1))
            break;
    }

    ss << fixed << setprecision(2) << 1.0 * count / mes.size();
        
    MessageBox(0, (L"������� ����� �������� �� ��������: " + ss.str() + L".").c_str(), ss.str().c_str(),
        MB_OK | MB_ICONINFORMATION);

    return 0;
}