
 var pickerDefault = new Pikaday(
    {
        field: document.getElementsByClassName('datepicker'),
    });

    var pickerTheme = new Pikaday(
    {
        field: document.getElementById('datepicker-theme'),
        theme: 'dark-theme'
    });
    
    var pickerTriangle = new Pikaday(
    {
        field: document.getElementById('datepicker-triangle'),
        theme: 'triangle-theme'
    });