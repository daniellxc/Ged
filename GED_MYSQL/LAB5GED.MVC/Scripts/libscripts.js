function Voltar() {

    history.go(-1);

}

function BindDDL(trigger, target, controller, action) {
  
     
   
    $(target).empty();
   
            $.ajax({
                type: 'POST',
                url:  "/ged/"+controller+"/"+action, // we are calling json method

                dataType: 'json',

                data: { id: $(trigger).val() },
                // here we are get value of selected country and passing same value

                
                success: function (states) {
                  
                    // states contains the JSON formatted list
                    // of states passed from the controller

                    $.each(states, function (i, state) {
                        $(target).append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                        // here we are adding option for States

                    });
                },
                error: function (ex) {
                    alert('erro ao recuperar itens.' + ex);
                }

            });
            $(target).append('<option value="">---</option>');
            
            return false;
       
   
}