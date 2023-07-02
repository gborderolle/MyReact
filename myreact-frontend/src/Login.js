import React, { Fragment, useState } from 'react';
import axios from 'axios';

function Login(){
    const [name, setName] = useState('');
    const [password, setPassword] = useState('');

    const handleNameChange = (value) =>{
        setName(value);
    }
    const handlePasswordChange = (value) =>{
        setPassword(value);
    }

    const handleLogin = () =>{
        const data = {
            Username : name,
            Password : password
        };

        const url = 'https://localhost:7166/api/Access/Login';
        axios.post(url,data)
        .then((result) => {
            alert(result.data);
        }).catch((error)=>{
            alert(error);
        })
    }

    return(
        <Fragment>
        <label>Nombre</label>
        <input type="text" id="txtName" placeholder="Ingresar nombre" onChange={(e) => handleNameChange(e.target.value)}/><br></br>
        <label>Contraseña</label>
        <input type="password" id="txtPassword" placeholder="Ingresar contraseña" onChange={(e) => handlePasswordChange(e.target.value)}/><br></br>
        <br></br>
        <button onClick={() => handleLogin()}>Login</button>
        </Fragment>
    )
}

export default Login;