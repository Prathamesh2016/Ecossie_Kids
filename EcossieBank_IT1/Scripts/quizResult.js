window.addEventListener('load', () => {

    // Via Query parameters - GET
    /* const params = (new URL(document.location)).searchParams;
    const name = params.get('name');
    const surname = params.get('surname'); */

    // Via local Storage
    /* const name = localStorage.getItem('NAME');
    const surname = localStorage.getItem('SURNAME'); */

    const quiz1result1 = sessionStorage.getItem('QUIZ1RESULT');
    const quiz1result2 = sessionStorage.getItem('QUIZ2RESULT');
    const quiz1result3 = sessionStorage.getItem('QUIZ3RESULT');


    document.getElementById('result-quiz1').innerHTML = quiz1result1;
    document.getElementById('result-quiz2').innerHTML = quiz1result2;
    document.getElementById('result-quiz3').innerHTML = quiz1result3;

})