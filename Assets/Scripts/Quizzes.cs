using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;




public class Quizzes : MonoBehaviour
{
    public GameObject questLabel, scoreLabel, finishLabel, cntLabel;

    public GameObject ans1, ans2, ans3, ans4;
    private GameObject clicked;
    public GameObject restartButton;
    public GameObject[] buttons = new GameObject[4];
    public GameObject[] buttonT = new GameObject[4];
    private string ActiveSceneName;
    private string trueAnswer;
    int score = 0, tried = 1;

    void Start()
    {
        ActiveSceneName = SceneManager.GetActiveScene().name;
        buttons[0] = GameObject.Find("Ans1");
        buttons[1] = GameObject.Find("Ans2");
        buttons[2] = GameObject.Find("Ans3");
        buttons[3] = GameObject.Find("Ans4");
        buttonT[0] = GameObject.Find("ButtonA");
        buttonT[1] = GameObject.Find("ButtonB");
        buttonT[2] = GameObject.Find("ButtonC");
        buttonT[3] = GameObject.Find("ButtonD");
        for (int i = 0; i < 4; i++)
            buttonT[i].GetComponent<Button>().interactable = false;
        finishLabel.GetComponent<Text>().gameObject.SetActive(false);
        cntLabel.GetComponent<Text>().text = tried + " - savol";
        restartButton.GetComponent<Button>().gameObject.SetActive(false);
        if (ActiveSceneName == "QuizScene")
            QuizPlay();
        else
        if (ActiveSceneName == "QuizScene2")
            QuizPlay2();
        else
        if (ActiveSceneName == "QuizScene3")
            QuizPlay3();
        else
        if (ActiveSceneName == "QuizScene4")
            QuizPlay4();

        //        StartCoroutine(QuizCheck())
    }
    void QuizPlay()
    {
        string[] test = new string[170]{"90 minut necha sekundga teng ?","5 400","4 500","3 600","1 800","Yo`lning asosiy o’lchov birligini aniqlang.","m","sm","dm","km","Jismning bosib o’tgan yo’li qaysi harf bilan belgilanadi ?","F ","S ","t ","ρ","Jismning fazoda qoldirgan izi qanday ataladi ?","trayektoriya","to`g`ri chiziq","moddiy nuqta","egri chiziq","Jism harakat trayektoriyasining uzunligi qanday ataladi va qaysi harf bilan belgilanadi?","yo`l, S ","uzunlik , S","yo`l, l","vaqt, t","1500 g necha kg ga teng ?","1,5","15","150","1 500 000","Gapni to’ldiring: ” Jism trayektoriyasining uzunligi uning o`z o`lchamlaridan juda katta bo`lganda, u …. deb ataladi. “","moddiy nuqta","sanoq jismi","ixtiyoriy jism","o`rganilayotgan jism","1 soat 40 minut necha sekund ?","6 000","10 000","2 400","3 600","Gapni to’ldiring: “… deb, jismning vaqt o’tishi bilan fazodagi o’rnining boshqa jismlarga nisbatan o’zgarishiga aytiladi”.","mexanik harakat","tekis harakat","notekis harakat","ilgarilanma harakat","Gapni to’ldiring: ” Jism massasini topish uchun uning zichligini hajmi …. ….. kerak. “","ga ko’paytirish","ga qo’shish","ga bo’lish","dan ayirish","180 km/soat necha m/s ga teng ?","50","18","180","5","m/s2 qanday kattalikning asosiy o’lchov birligi ?","tezlik","yo`l","ko`chish","tezlanish","Gapni to’ldiring: “Tekis harakatda jism tezligining yo`nalishi va son qiymati ….. ``","o`zgarmaydi ","kamayib boradi","ortib boradi","nolda teng bo`ladi","Tezlikning eng katta o’lchov birligi qaysi javobda keltirilgan ?","m/s","km/soat","km/s","m/min","Gapni to’ldiring: “To`g`ri chiziqli tekis sekinlanuvchan harakatda tezlik va tezlanish ….. yo`nalgan bo`ladi.”","o`zaro qarama-qarshi","bir xil","ixtiyoriy ","o`zaro bir-biriga tik","Tekis sekinlanuvchan harakat uchun tezlanish qanday bo’ladi ?","a<0","ixtiyoriy","a=0","a>0","40 m/s necha km/soat ga teng ?","144","90","14,4","1440","Avtomobilning tezligi 20 s da 5 m/s dan 20 m/s gacha oshdi. Uning tezlanishi nimaga teng ( m/s2)?","0,75","12,5","5","1,5","Quyidagi kattaliklarning qaysi biri vektor kattalik ?","tezlik, tezlanish, ko`chish","yo`l, tezlik , ko`chish","vaqt, yo`l , tezlik","tezlanish, yo`l , vaqt","To’g’ri chiziqli tekis tezlanuvchan harakatda tezlanish qanday yo’nalgan ?","harakat yo’nalishi bilan bir xil ","harakat yo’nalishiga teskari ","harakat yo’nalishiga tik","tezlanish yo’nalishga ega emas","Qaysi holda kuzatuvchi uchun kuzatilayotgan jism moddiy nuqta bo’la oladi ?","balandda uchayotgan samolyot ","aeroportdagi samolyot","sport zalidagi o’quvchi","sumkadagi kitob ","Jismning tezligi 5 s da 2,5 m/s dan 4,5 m/s gacha oshdi. Harakat tezlanishi nimaga teng (m/s2 ) ?","0,4","0,8","0,2","1,4","720 km/soat necha m/s ga teng ?","200","50","72","20","Gapni to’ldiring: “ Vaqt birligi ichida jism tezligining o’zgarishi ..... deb ataladi. ”","tezlanish","chiziqli tezlik ","burchak tezlik","erkin tushish","Boshlang’ich tezliksiz to`g`ri chiziqli tekis tezlanuvchan harakatlanayotgan jismning 3- s oxiridagi tezligi aniqlang ( m/s ). Tezlanish 1,5 m/s2.","4,5","3,6","5,4","3,2","Poyezd 40 m/s boshlang’ich tezlik bilan stansiyaga yaqinlashmoqda. Uning tezlanishi -1,6 m/s2 bo`lsa, necha sekunddan keyin to`xtaydi ?.","25","30","20","15","Jismning tekis tezlanuvchan harakati uchun tezlanishi qanday bo’ladi ?","a>0","a=0","a<0","ixtiyoriy","Gapni to’ldiring: “ Agar moddiy nuqta ixtiyoriy teng vaqtlar ichida teng masofalarni bosib o’tsa, bunday harakat ... deb ataladi. ”","tekis harakat ","tekis tezlanuvchan harakat ","no tekis harakat","tekis sekinlanuvchanharakat.","Qaysi javobda tezlanish birliklari to’g’ri ko’rsatilgan? I. m/s II. m/s2 III. sm/s IV. km/s V. m/minut VI. km/s2","II, VI ","II, III, IV, VI","I, II, V","III, IV, VI","To`g`ri chiziqli tekis tezlanuvchan harakatda o`rtacha tezlik formulasini aniqlang (v0=0)","vo`rt=at/2","vo`rt=at2","vo`rt=t2 /2a","vo`rt=at2/2","Gapni to`ldiring: “To`g`ri chiziqli tekis sekinlanuvchan harakatda jismning tezlanishi tezlik vektori ……”","ga teskari yo`naladi","bilan bir xil yo`naladi","ga tik yo`naladi","bilan ixtiyoriy burchak hosil qiladi","10 m/s necha km/soat ga teng ?","36","90","54","72","To’g’ri chiziqli tekis tezlanuvchan harakatda tezlanish qanday yo’nalgan ?","harakat yo’nalishi bilan bir xil ","harakat yo’nalishiga teskari","harakat yo’nalishiga tik","tezlanish yo’nalishga ega emas","Jism boshlang’ich tezliksiz to’g’ri chiziqli tekis tezlanuvchan harakatlanganda tezligi qaysi formuladan aniqlanadi ?","v=at ","v=v0+at","v=v0+gt","v=v0+at/2"};
        int cnt = Random.Range(0, 34);
        trueAnswer = test[cnt*5 + 1];
        questLabel.GetComponent<Text>().text = test[cnt * 5];
        cntLabel.GetComponent<Text>().text = tried + " - savol";
            string[] ans = new string[4] { test[cnt * 5 + 1], test[cnt * 5 + 2], test[cnt * 5 + 3], test[cnt * 5 + 4]};
        Random.Range(1, 4);

        for (int i = 0; i < 4; i++)
        {
            string temp = ans[i];
            int randomIndex = Random.Range(i, 4);
            ans[i] = ans[randomIndex];
            ans[randomIndex] = temp;
        }
        ans1.GetComponent<Text>().text = ans[0];
        ans2.GetComponent<Text>().text = ans[1];
        ans3.GetComponent<Text>().text = ans[2];
        ans4.GetComponent<Text>().text = ans[3];
    }
    void QuizPlay2()
    {
        string[] test = new string[150] { "1 sm3 hajmli suv massasi qanchaga teng ?", "1g", "1 t", "1 kg", "aniqlab bo’lmaydi", "Jism massasi qaysi asbob bilan o’lchanadi ?", "tarozi", "menzurka", "dinamometr", "sekundomer", "Fizikada massa qanday asosiy birlikda o’lchanadi ?", "kilogramm", "tonna", "gramm", "milligramm", "Gapni to’ldiring: ” Modda zichligini topish uchun jism massasini uning hajmi …. kerak. “", "ga bo’lish...", "ga qo’shish...", "dan ayirish...", "ga ko’paytirish...", "0,25 kg massani grammlarda ifodalang", "250", "25", "25", "0,25", "6. Modda zichligi qaysi harf bilan belgilanadi ?", "ρ", "t", "m", "V", "1 litr necha m3 ga teng ?", "0, 001", "1", "0, 01", "1000", "Zichlik formulasidan jism massasini topish formulasini aniqlang", "m=ρV", "m=v/ρ", "m=ρ/V", "m=v3ρ", "O’lchamlari 10 sm dan bo’lgan kubga qanday hajmli suv sig’adi (litr ) ?", "1", "100", "10", "aniqlab bo’lmaydi", "10. 1500 g necha kgga teng ?", "1,5", "15", "15", "1500000", "Qanday turdagi moddalarning zichligi eng katta ?", "qattiq jismlar", "gazlar", "suyuqliklar", "gazlar va suyuqliklar", "Suyuqlik yoki gazga botirilgan jismga ta’sir etuvchi ko’taruvchi kuch qaysi formula yordamida aniqlanadi?", "F= ρs g Vj", "F=PS", "F=mg", "F=ρgh", "Dinamometrga osilgan yukni suyuqlikka botirsak, dinamometrning ko’rsatishi kamayadi. Bunga qaysi kuch sabab bo’ladi ?", "Arximed kuchi", "Og’irlik kuchi", "Yerning tortish kuchi", "Suyuqlikning ishqalanish kuchi", "Nuqtalar o’rnini to’ldiring: ” Agar jism og’irligi Arximed kuchidan katta bo’lsa, u holda jism suyuqlik ……", "....tubiga cho’kadi", "…ka qisman botgan holda suzib yuradi", "suyuqlik sirtiga butunlay qalqib chiqadi", "....ichiga muallaq holda turadi.", "1,25 tonna massani kg ga aylantiring", "1250", "12500", "125", "0,125", "“ Massa ” so’zining o’zbekcha ma’nosini aniqlang.", "“ bo’lak, parcha ”", "“ harakat “", "“ kuch ”", "“ holat ”", "Moddalar necha xil agregat xolatga ega?", "3", "2", "4", "Yaxlit", "Massasi 400kg bo’lgan jismning hajmi 0,8 m3 ga teng. Uning zichligini toping (kg/m3)", "500", "50", "5000", "320", "Massasi 6 kg bo’lgan jismning hajmi 0,001 m3 ga teng. Uning zichligini toping. (kg/m3)", "6000", "600", "0,006", "0,06", "Massasi 0,5 kg bo’lgan qotishmaning hajmi 0,1 dm3 ga teng. Uning zichligini toping. (kg/m3)", "5000", "0,05", "500", "5", "Massasi 400gr va zichligi 800 kg/m3 bo’lgan moddaning hajmini toping. (l)", "0,5", "5", "50", "0,05", "Tomoni 40 sm bo’lgan kub shaklidagi yaxlit jism granitdan yasalgan. Granitning zichligi 2,6 gr/sm3 ga teng. Uning massasini toping. (kg)", "166,4", "162", "160,2", "165", "Massasi 600 kg va zichligi 1,5 gr/sm3 bo’lgan moddaning hajmini toping. (m3)", "0,4", "9", "4", "0,9", "Massasi 11,36 kg bo’lgan aralshmaning hajmini (l) toping. Asalning zichligi 1,42 gr/sm3.", "8", "12", "6", "10", "1dm2 necha m2 ga teng?", "0,01", "0,1", "10", "0,001", "1 m2 necha mm2 ga teng?", "106", "104", "102", "44661", "Massasi 200mg bo’lgan zarraning hajmi 8mm3 ga teng. Uning zichligini toping. (gr/sm3)", "25", "4", "0,5", "0,25", "Asosining yuzi 60 sm2 va balandligi 6sm bo’lgan nikelning massasini toping (kg). NIkelning zichligi 8900 kg/m3 ga teng.", "32", "36", "42", "30", "Diametri 5dm bo’lgan shar shaklidagi yaxlit jism nikeldan yasalgan. Nikelning zichligi 8900 kg/m3 ga teng. Uning massasini aniqlang.", "582,2", "584,2", "445", "890", "Massasi 20kg bo’lgan toshning hajmi 4l ga teng. Uning zichligini toping. (kg/m3)", "5000", "80", "500", "800" };
        int cnt = Random.Range(0, 34);
        trueAnswer = test[cnt * 5 + 1];
        questLabel.GetComponent<Text>().text = test[cnt * 5];
        cntLabel.GetComponent<Text>().text = tried + " - savol";
        string[] ans = new string[4] { test[cnt * 5 + 1], test[cnt * 5 + 2], test[cnt * 5 + 3], test[cnt * 5 + 4] };
        Random.Range(1, 4);

        for (int i = 0; i < 4; i++)
        {
            string temp = ans[i];
            int randomIndex = Random.Range(i, 4);
            ans[i] = ans[randomIndex];
            ans[randomIndex] = temp;
        }
        ans1.GetComponent<Text>().text = ans[0];
        ans2.GetComponent<Text>().text = ans[1];
        ans3.GetComponent<Text>().text = ans[2];
        ans4.GetComponent<Text>().text = ans[3];
    }

    void QuizPlay3()
    {
        string[] test = new string[105] { "Elеktr tоki dеb nimаgа аytilаdi? ", "Zаryadlаngаn zаrrаlarning tаrtibli hаrаkаtiga", "Musbаt zаryadlаrning hаrаkаtigа", "Manfiy zаryadlаrning hаrаkаtigа", "Zаryadlаngаn zаrrаlаrning tаrtibsiz hаrаkаtigа", "Mеtаll o‘tkаzgichlаrdа elеktr tоki qаndаy vujudgа kеlаdi.", "Elеktrоnlаrning tаrtibli hаrаkаti tufаyli", "Iоnlаrning hаrаkаti tufаyli", "Elеktrоnlаrning hаrаkаti tufаyli", "Prоtоnlаrning hаrаkаti tufаyli", "Kuchlаnishni о`lchаsh uchun qаndаy аsbоbdаn fоydаlаnish mumkin?", "Vоltmеtrdan ", "Dinоmоmеtrdan ", "Аmpеrmеtrdan", "Elеktrоskоpdan", "Vоltmеtr zаnjirgа qаndаy ulаnаdi? ", "Vоltmеtr zаnjirgа pаrаllеl ulanadi.", "Vоltmеtr zаnjirgа kеtmа-kеt ulanadi.", "Vоltmеtr zаnjirgа to‘g‘ri ulanadi", "Vоltmеtr zаnjirgа pаrаllеl yoki kеtmа-kеt ulanadi ", "Xalqaro birliklar sistemasida kuchlanish qаndаy birlikdа о`lchаnаdi ?", "Vоlt", "Kulоn ", "Ampеr", "Jоul", "Quyidаgi kеltirilgаn fоrmulаlаrdаn qаysi biri elektr kuchlanish formulasini ifоdаlаydi? ", "U =A/q", "C=C1+C2 ", "A=Uq ", "P=I·U", "O‘tkаzgichlаrning qаrshiligi nimаgа bоg‘liq", "O‘tkаzgichning qаrshiligi uzunligigа to‘g‘ri prоpоrsiоnаl, kо`ndаlаng kеsim yuzigа tеskаri prоpоrsiоnаl", "O‘tkаzgichning uzunligigа to‘g‘ri prоpоrsiоnаl", "O‘tkаzgichning kеsim yuzigа tеskаri prоpоrsiоnаl", "O‘tkаzgichning qаlinligigа to‘g‘ri prоpоrsiоnаl, kо`ndаlаng kеsim yuzigа tеskаri prоpоrsiоnаl", "Rеzistor qanday asbob?", "Aniq qarshilikka ega bo‘lgan radiodеtal.", "Kattaligi o‘zgaradigan qarshilik.", "Tokni rostlash uchun qo‘llaniladigan asbob.", "Qarshilikni o‘lchovchi asbob.", "Qarshiligi 8 Ω va 10 Ω bo‘lgan o‘tkazgichlar parallеl ulangan. Umumiy qarshilik nimaga tеng?", "4,4 Ω", "18 Ω ", "2 Ω", "9 Ω ", "Potensiometrning vazifasi nimadan iborat?", "Elektr zanjirida kuchlanishni rostlaydigan elektr asbob", "O‘zgarmas qarshilikni o‘lchaydigan asbob", "Elektr zanjirida tok kuchini rostlaydigan elektr asbob", "Qarshilikni o‘lchaydigan asbob ", "Gapni to‘ldiring “Birlik vaqt ichida o‘tkazgichning ko‘ndalang kеsim yuzasidan oqib o‘tgan zaryad miqdoriga .... dеyiladi”.", "…tok kuchi ", "… kuchlanish ", "…elеktr toki ", "…elеktr zanjiri", "3 tа o‘tkаzgich kеtmа-kеt ulаngаndа zаnjirdаgi tоk kuchi qаndаy bo‘lаdi.", "I1=I2 =I3 ", "I1<I2 <I3", "I1>I2 >I3 ", "I1+I2 +I3", "Qаrshiliklаri 4 W vа 9 W bo‘lgаn o‘tkаzgichlаr pаrаllеl ulаngаn. Ulаrning umumiy qаrshiligini tоping.", "2,7 W", "28 W ", "27W", "36W", "Qаrshiligi 1200 W, vоltmеtr 10 V ni ko‘rsаtib turgаn vаqtdа undаn o‘tаyotgаn tоk kuchini tоping.", "0,0083 A ", "0,08 A", "120A ", "0", "Qarshiliklari 8 Ω dan bo‘lgan 2 ta o‘tkazgich avval kеtma-kеt, so‘ngra parallеl ulandi. Bunda umumiy qarshilik qanday o‘zgaradi?", "4 marta kamayadi.", "2 marta ortadi ", "2 marta kamayadi ", "4 marta ortadi ", "Lаmpа qisqichlаridаgi kuchlаnish 120 V bo‘lgаndа lаmpаоrqаli 0,5А bо`lgаn tоk о`tаdi. Lаmpаning qаrshiligini аniqlаng .", "240 W", "600 W ", "24 W", "60 W", "Pаrаllеl ulаngаndа zаnjirdаgi kuchlаnish nimаgа tеng.", "Uu= U1= U2", "Uu= U1+ U2 ", "Uu=U1 -U2", "Uu>U1> U2 ", "Аmpеrmеtr zаnjirgа qаndаy ulаnаdi.", "Kеtmа-kеt ulаnаdi", "Pаrаllеl ulаnаdi ", "Aralash ulаnаdi", "Elektr chizmasiga qarab pаrаllеl yoki kеtmа-kеt ulаnаdi", "Qarshiliklari 10 Wbo‘lgan 2 ta o‘tkazgichlar parallel ulangan. Umumiy qarshilik nimaga teng?", "5 W", "25 W ", "6 W", "12,5W", "4 tа o‘tkаzgich kеtmа-kеt ulаngаndа zаnjirdаgi qarshilik qаndаy bo‘lаdi.", "R1+R2 +R3 +R3 ", "R1=R2 =R3=R4 ", "R1<R2 <R3 <R4 ", "R1>R2 >R3 >R4 ", "Еlеktr kuchlanish qanday birlikda o‘lchanadi?", "Volt", "Kulon ", "Ampеr", "Vatt", };
        int cnt = Random.Range(0, 21);
        trueAnswer = test[cnt * 5 + 1];
        questLabel.GetComponent<Text>().text = test[cnt * 5];
        cntLabel.GetComponent<Text>().text = tried + " - savol";
        string[] ans = new string[4] { test[cnt * 5 + 1], test[cnt * 5 + 2], test[cnt * 5 + 3], test[cnt * 5 + 4] };
        Random.Range(1, 4);

        for (int i = 0; i < 4; i++)
        {
            string temp = ans[i];
            int randomIndex = Random.Range(i, 4);
            ans[i] = ans[randomIndex];
            ans[randomIndex] = temp;
        }
        ans1.GetComponent<Text>().text = ans[0];
        ans2.GetComponent<Text>().text = ans[1];
        ans3.GetComponent<Text>().text = ans[2];
        ans4.GetComponent<Text>().text = ans[3];
    }
    void QuizPlay4()
    {
        string[] test = new string[105] {"Elеktr tоki dеb nimаgа аytilаdi? ", "Zаryadlаngаn zаrrаlarning tаrtibli hаrаkаtiga", "Musbаt zаryadlаrning hаrаkаtigа", "Manfiy zаryadlаrning hаrаkаtigа", "Zаryadlаngаn zаrrаlаrning tаrtibsiz hаrаkаtigа", "Mеtаll o‘tkаzgichlаrdа elеktr tоki qаndаy vujudgа kеlаdi.", "Elеktrоnlаrning tаrtibli hаrаkаti tufаyli", "Iоnlаrning hаrаkаti tufаyli", "Elеktrоnlаrning hаrаkаti tufаyli", "Prоtоnlаrning hаrаkаti tufаyli", "Kuchlаnishni о`lchаsh uchun qаndаy аsbоbdаn fоydаlаnish mumkin?", "Vоltmеtrdan ", "Dinоmоmеtrdan ", "Аmpеrmеtrdan", "Elеktrоskоpdan", "Vоltmеtr zаnjirgа qаndаy ulаnаdi? ", "Vоltmеtr zаnjirgа pаrаllеl ulanadi.", "Vоltmеtr zаnjirgа kеtmа-kеt ulanadi.", "Vоltmеtr zаnjirgа to‘g‘ri ulanadi", "Vоltmеtr zаnjirgа pаrаllеl yoki kеtmа-kеt ulanadi ", "Xalqaro birliklar sistemasida kuchlanish qаndаy birlikdа о`lchаnаdi ?", "Vоlt", "Kulоn ", "Ampеr", "Jоul", "Quyidаgi kеltirilgаn fоrmulаlаrdаn qаysi biri elektr kuchlanish formulasini ifоdаlаydi? ", "U =A/q", "C=C1+C2 ", "A=Uq ", "P=I·U", "O‘tkаzgichlаrning qаrshiligi nimаgа bоg‘liq", "O‘tkаzgichning qаrshiligi uzunligigа to‘g‘ri prоpоrsiоnаl, kо`ndаlаng kеsim yuzigа tеskаri prоpоrsiоnаl", "O‘tkаzgichning uzunligigа to‘g‘ri prоpоrsiоnаl", "O‘tkаzgichning kеsim yuzigа tеskаri prоpоrsiоnаl", "O‘tkаzgichning qаlinligigа to‘g‘ri prоpоrsiоnаl, kо`ndаlаng kеsim yuzigа tеskаri prоpоrsiоnаl", "Rеzistor qanday asbob?", "Aniq qarshilikka ega bo‘lgan radiodеtal.", "Kattaligi o‘zgaradigan qarshilik.", "Tokni rostlash uchun qo‘llaniladigan asbob.", "Qarshilikni o‘lchovchi asbob.", "Qarshiligi 8 Ω va 10 Ω bo‘lgan o‘tkazgichlar parallеl ulangan. Umumiy qarshilik nimaga tеng?", "4,4 Ω", "18 Ω ", "2 Ω", "9 Ω ", "Potensiometrning vazifasi nimadan iborat?", "Elektr zanjirida kuchlanishni rostlaydigan elektr asbob", "O‘zgarmas qarshilikni o‘lchaydigan asbob", "Elektr zanjirida tok kuchini rostlaydigan elektr asbob", "Qarshilikni o‘lchaydigan asbob ", "Gapni to‘ldiring “Birlik vaqt ichida o‘tkazgichning ko‘ndalang kеsim yuzasidan oqib o‘tgan zaryad miqdoriga .... dеyiladi”.", "…tok kuchi ", "… kuchlanish ", "…elеktr toki ", "…elеktr zanjiri", "3 tа o‘tkаzgich kеtmа-kеt ulаngаndа zаnjirdаgi tоk kuchi qаndаy bo‘lаdi.", "I1=I2 =I3 ", "I1<I2 <I3", "I1>I2 >I3 ", "I1+I2 +I3", "Qаrshiliklаri 4 W vа 9 W bo‘lgаn o‘tkаzgichlаr pаrаllеl ulаngаn. Ulаrning umumiy qаrshiligini tоping.", "2,7 W", "28 W ", "27W", "36W", "Qаrshiligi 1200 W, vоltmеtr 10 V ni ko‘rsаtib turgаn vаqtdа undаn o‘tаyotgаn tоk kuchini tоping.", "0,0083 A ", "0,08 A", "120A ", "0", "Qarshiliklari 8 Ω dan bo‘lgan 2 ta o‘tkazgich avval kеtma-kеt, so‘ngra parallеl ulandi. Bunda umumiy qarshilik qanday o‘zgaradi?", "4 marta kamayadi.", "2 marta ortadi ", "2 marta kamayadi ", "4 marta ortadi ", "Lаmpа qisqichlаridаgi kuchlаnish 120 V bo‘lgаndа lаmpаоrqаli 0,5А bо`lgаn tоk о`tаdi. Lаmpаning qаrshiligini аniqlаng .", "240 W", "600 W ", "24 W", "60 W", "Pаrаllеl ulаngаndа zаnjirdаgi kuchlаnish nimаgа tеng.", "Uu= U1= U2", "Uu= U1+ U2 ", "Uu=U1 -U2", "Uu>U1> U2 ", "Аmpеrmеtr zаnjirgа qаndаy ulаnаdi.", "Kеtmа-kеt ulаnаdi", "Pаrаllеl ulаnаdi ", "Aralash ulаnаdi", "Elektr chizmasiga qarab pаrаllеl yoki kеtmа-kеt ulаnаdi", "Qarshiliklari 10 Wbo‘lgan 2 ta o‘tkazgichlar parallel ulangan. Umumiy qarshilik nimaga teng?", "5 W", "25 W ", "6 W", "12,5W", "4 tа o‘tkаzgich kеtmа-kеt ulаngаndа zаnjirdаgi qarshilik qаndаy bo‘lаdi.", "R1+R2 +R3 +R3 ", "R1=R2 =R3=R4 ", "R1<R2 <R3 <R4 ", "R1>R2 >R3 >R4 ", "Еlеktr kuchlanish qanday birlikda o‘lchanadi?", "Volt", "Kulon ", "Ampеr", "Vatt", };
        int cnt = Random.Range(0, 21);
        trueAnswer = test[cnt * 5 + 1];
        questLabel.GetComponent<Text>().text = test[cnt * 5];
        cntLabel.GetComponent<Text>().text = tried + " - savol";
        string[] ans = new string[4] { test[cnt * 5 + 1], test[cnt * 5 + 2], test[cnt * 5 + 3], test[cnt * 5 + 4] };
        Random.Range(1, 4);

        for (int i = 0; i < 4; i++)
        {
            string temp = ans[i];
            int randomIndex = Random.Range(i, 4);
            ans[i] = ans[randomIndex];
            ans[randomIndex] = temp;
        }
        ans1.GetComponent<Text>().text = ans[0];
        ans2.GetComponent<Text>().text = ans[1];
        ans3.GetComponent<Text>().text = ans[2];
        ans4.GetComponent<Text>().text = ans[3];
    }

    //   IEnumerator QuizCheck()
    IEnumerator waiter(bool isTrue = true)
    {
        yield return new WaitForSeconds(1);
        if (ActiveSceneName == "QuizScene")
            QuizPlay();
        else
        if (ActiveSceneName == "QuizScene2")
            QuizPlay2();
        else
        if (ActiveSceneName == "QuizScene3")
            QuizPlay3();
        else
        if (ActiveSceneName == "QuizScene4")
            QuizPlay4();


        tried++; 
        cntLabel.GetComponent<Text>().text = tried + " - savol";
        for (int i = 0; i < 4; i++)
        {
            buttons[i].GetComponent<Image>().color = Color.white;
            buttons[i].GetComponent<Button>().interactable = true;
            
        }
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && EventSystem.current.currentSelectedGameObject.name != "MainMenuButton" && tried != 6)
        {
            clicked = EventSystem.current.currentSelectedGameObject;
            if (clicked != null && clicked.GetComponentInChildren<Text>().text == trueAnswer)
            {
                clicked.GetComponent<Image>().color = Color.green;
                score++;
                //scoreLabel.GetComponent<Text>().text = "Natija: " + tried + " ta urinish," + score + " ta to'g'ri javob!";
                scoreLabel.GetComponent<Text>().text = "Natija: " + score + " ta to'g'ri javob!";
                for (int i = 0; i < 4; i++)
                {
                    buttons[i].GetComponent<Button>().interactable = false;
                }
                    StartCoroutine(waiter(true));
            }
            else if (clicked.GetComponentInChildren<Text>().text != trueAnswer)
            {
                clicked.GetComponent<Image>().color = Color.red;

                for (int i = 0; i < 4; i++)
                {
                    buttons[i].GetComponent<Button>().interactable = false;
                    if (buttons[i].GetComponentInChildren<Text>().text == trueAnswer)
                    {
                        buttons[i].GetComponentInParent<Image>().color = Color.green;
                        StartCoroutine(waiter(false));
                    }
                }
            }
        }
        else
        if (tried == 6)
        {
            finishLabel.GetComponent<Text>().text = score + " ta to'g'ri javob!";
            scoreLabel.GetComponent<Text>().text = "Natija: 0";
            questLabel.GetComponent<Text>().gameObject.SetActive(false);
            cntLabel.GetComponent<Text>().gameObject.SetActive(false);
            scoreLabel.GetComponent<Text>().gameObject.SetActive(false);
            finishLabel.GetComponent<Text>().gameObject.SetActive(true);
            restartButton.GetComponent<Button>().gameObject.SetActive(true);
            for (int i = 0; i < 4; i++)
            {
                buttons[i].GetComponent<Button>().gameObject.SetActive(false);
                buttonT[i].GetComponent<Button>().gameObject.SetActive(false);
            }

        }
    }
    public void reStart()
    {
        tried = 1;
        score = 0;
        
        questLabel.GetComponent<Text>().gameObject.SetActive(true);
        cntLabel.GetComponent<Text>().gameObject.SetActive(true);
        scoreLabel.GetComponent<Text>().gameObject.SetActive(true);
        finishLabel.GetComponent<Text>().gameObject.SetActive(false);
        restartButton.GetComponent<Button>().gameObject.SetActive(false);
        for (int i = 0; i < 4; i++)
        {
            buttons[i].GetComponent<Button>().gameObject.SetActive(true);
            buttonT[i].GetComponent<Button>().gameObject.SetActive(true);
        }
        if (ActiveSceneName == "QuizScene")
            QuizPlay();
        else
        if (ActiveSceneName == "QuizScene2")
            QuizPlay2();
        else
        if (ActiveSceneName == "QuizScene3")
            QuizPlay3();
        else
        if (ActiveSceneName == "QuizScene4")
            QuizPlay4();
    }
}
