$(() => {
    $("#add-row").on('Click', function () {
        var rows = $('#people-row .row person-row').length;
        var newRow = `
        <div class="row person-row">
        <input class="form-control" type="text" name="people[${rows}].firstname" placeholder="First Name"/>
        </div>
        
         <div class="row person-row">
        <input class="form-control" type="text" name="people[${rows}].lastname" placeholder="Last Name"/>
        </div>

         <div class="row person-row">
        <input class="form-control" type="text" name="people[${rows}].age" placeholder="Age"/>
        </div>
        </div>
        `;
        $("#people-row").append(rows);
    })
})