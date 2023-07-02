import React, { Fragment, useState } from 'react';
import axios from 'axios';

function Registration(){
    const [name, setName] = useState('');
    const [phone, setPhone] = useState('');
    const [email, setEmail] = useState('');
    const [address, setAddress] = useState('');

    const handleNameChange = (value) =>{
        setName(value);
    }
    const handlePhoneChange = (value) =>{
        setPhone(value);
    }
    const handleEmailChange = (value) =>{
        setEmail(value);
    }
    const handleAddressChange = (value) =>{
        setAddress(value);
    }

    const handleSave = () =>{
        const data = {
            Name : name,
            Phone : phone,
            Email : email, 
            Address : address,
            IsActive : 1
        };

        const url = 'https://localhost:7166/api/Test/Registration';
        axios.post(url,data)
        .then((result) => {
            alert(result.data);
        }).catch((error)=>{
            alert(error);
        })
    }

    return(
        <Fragment>
        <div>Agregar empleado</div>
        <label>Nombre</label>
        <input type="text" id="txtName" placeholder="Ingresar nombre" onChange={(e) => handleNameChange(e.target.value)}/><br></br>
        <label>Teléfono</label>
        <input type="text" id="txtPhone" placeholder="Ingresar teléfono" onChange={(e) => handlePhoneChange(e.target.value)}/><br></br>
        <label>Email</label>
        <input type="text" id="txtEmail" placeholder="Ingresar email" onChange={(e) => handleEmailChange(e.target.value)}/><br></br>
        <label>Dirección</label>
        <input type="text" id="txtAddress" placeholder="Ingresar dirección" onChange={(e) => handleAddressChange(e.target.value)}/><br></br>
        <br></br>
        <button onClick={() => handleSave()}>Guardar</button>
        </Fragment>
    )
}

export default Registration;