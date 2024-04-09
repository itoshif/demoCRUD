function addEmployee() {
    const Name = document.getElementById('name').value;
    const Email = document.getElementById('email').value;
    const Phone = document.getElementById('phone').value;

    const employee = {
        name: Name,
        email: Email,
        phone: Phone
    };

    fetch('/Home/AddEmployee', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(employee)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Failed to add employee');
            }
            return response.json();
        })
        .then(data => {

            console.log('Employee added successfully', data);
        })
        .catch(error => {

            console.error('Error adding employee', error);
        });
}
//function to update'
function updateEmployee() {
    const Id = document.getElementById('id').value;
    const Name = document.getElementById('name').value;
    const Email = document.getElementById('email').value;
    const Phone = document.getElementById('phone').value;

    const employee = {
        Id=id,
        Name=name,
        Email=email,
        Phone=phone

    };

    fetch('/Home/UpdateEmployee', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(employee)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Failed to update emplopyee');
            }
            return response.json();
        })

        .then(data => {
            console.log('Employee updated', data);
        })

        .then(error => {
            console.log('Error updating employee', error);
        });
}
//delete employee
function deletEmployee() {
    const Id = document.getElementById('id').value;
    const employee = {
        Id=id,
    };

    fetch('/Home/DeleteEmployee', {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(employee)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Failed to delete emplopyee');
            }
            return response.json();
        })

        .then(data => {
            console.log('Employee deleted', data);
        })

        .then(error => {
            console.log('Error deleting employee', error);
        });
}


//const addBtn = document.getElementById('ademp');
//const updateBtn = document.getElementById('upemp');
//const deleteBtn = document.getElementById('delemp');
//const showBtn = document.getElementById('showtb');

//addBtn.addEventListener('click', addEmployee);
//updateBtn.addEventListener('click', updateEmployee);
//deleteBtn.addEventListener('click', deletEmployee);
//showBtn.addEventListener('click');