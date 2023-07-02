import React, { Fragment, useState } from 'react';
import axios from 'axios';

function AddUser(){
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const handleUsernameChange = (value) =>{
        setUsername(value);
    }
    const handlePasswordChange = (value) =>{
        setPassword(value);
    }

    const handleSave = () =>{
        const data = {
            Username : username,
            Password : password
        };

        const url = 'https://localhost:7166/api/User/AddUser';
        axios.post(url,data)
        .then((result) => {
            alert(result.data);
        }).catch((error)=>{
            alert(error);
        })
    }

    return(
        <Fragment>
        <div>Agregar usuario</div>
        <label>Usuario</label>
        <input type="text" id="txtName" placeholder="Ingresar usuario" onChange={(e) => handleUsernameChange(e.target.value)}/><br></br>
        <label>Contraseña</label>
        <input type="text" id="txtPhone" placeholder="Ingresar contraseña" onChange={(e) => handlePasswordChange(e.target.value)}/><br></br>
        <br></br>
        <button onClick={() => handleSave()}>Guardar</button>
        </Fragment>
    )
}

export default AddUser;