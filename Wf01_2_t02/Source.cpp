// Написать приложение, которое «угадывает» задуманное пользователем число от 1 до 100.
// Для запроса к пользователю использовать окна сообщений.
// После того, как число отгадано, необходимо вывести количество попыток, потребовавшихся для этого,
// и предоставить пользователю возможность сыграть еще раз, не завершая программу.
// Окна сообщений следует оформить кнопками и иконками в соответствии с конкретной ситуацией.

#include <Windows.h>
#include <cmath>

INT WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPSTR IpszCmdLine, int nCmdShow)
{
    wchar_t szTitle[] = L"Отгадываем число";
    wchar_t szNumQuery[] = L"Загадайте число от 1 до 100!";
    wchar_t szEqualQuery[] = L"Загаданное число меньше или равно %d?";
    wchar_t szFound[] = L"Было отгадано число %d за %d попыток.\nПовторить?";
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