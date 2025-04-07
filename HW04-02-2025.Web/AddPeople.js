$(() => {

    let index = 1;

    $("#add-row").on('Click', function () {
        $('#people-row).append(AddARow())

        index++;
    });

    function AddARow() {
        return ` <div class="row person-row">
         <div class="col-md-5">
        <input class="form-control" type="text" name="people[${index}].firstname" placeholder="First Name"/>
        </div>
        
         <div class="col-md-5">
        <input class="form-control" type="text" name="people[${index}].lastname" placeholder="Last Name"/>
        </div>

        <div class="col-md-5">
        <input class="form-control" type="text" name="people[${index}].age" placeholder="Age"/>
        </div>
    </div>`
    }
})