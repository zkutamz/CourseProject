import React from 'react';

export default function AuthGate(props) {
    return (
        <div className="sign_in_up_bg">
            <div className="container">
                <div className="row justify-content-lg-center justify-content-md-center">
                    <div className="col-lg-12">
                        <div className="main_logo25" id="logo">
                            <a href="index.html"><img src="images/logo.svg" alt="" /></a>
                            <a href="index.html"><img className="logo-inverse" src="images/ct_logo.svg" alt="" /></a>
                        </div>
                    </div>
                    <div className="col-lg-6 col-md-8">
                        <props.component />
                        <div className="sign_footer">
                            <img src="images/sign_logo.png" alt="" />
                            © 2020 <strong>Cursus</strong>. All Rights Reserved.
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}
