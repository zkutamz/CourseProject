import React, { useEffect } from 'react'
import Footer from '../../../components/Footer';
import { useState } from 'react';
export default function CertificateResult(props) {
    const [resultDta, setResultData]= useState({})
    useEffect(async() => {
       await console.log("Data: ",props.history.location.data.result.id);
      }, [])
    return (
        <>
            <header class="header clearfix">
                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <div class="back_link">
                                <a href="index.html" class="hde151">Back To Cursus</a>
                                <a href="index.html" class="hde152">Back</a>
                            </div>
                            <div class="ml_item">
                                <div class="main_logo main_logo15" id="logo">
                                    <a href="index.html"><img src="images/logo.svg" alt=""/></a>
                                    <a href="index.html"><img class="logo-inverse" src="images/ct_logo.svg" alt=""/></a>
                                </div>
                            </div>
                            <div class="header_right pr-0">
                                <ul>
                                    <li class="ui top right pointing dropdown">
                                        <a href="#" class="opts_account">
                                            <img src="images/hd_dp.jpg" alt=""/>
                                        </a>
                                        <div class="menu dropdown_account">
                                            <div class="channel_my">
                                                <div class="profile_link">
                                                    <img src="images/hd_dp.jpg" alt=""/>
                                                        <div class="pd_content">
                                                            <div class="rhte85">
                                                                <h6>Joginder Singh</h6>
                                                                <div class="mef78" title="Verify">
                                                                    <i class='uil uil-check-circle'></i>
                                                                </div>
                                                            </div>
                                                            <span><a href="/cdn-cgi/l/email-protection" class="__cf_email__" data-cfemail="f790969a95989bcec3c4b7909a969e9bd994989a">[email&#160;protected]</a></span>
                                                        </div>
                                                </div>
                                                <a href="my_instructor_profile_view.html" class="dp_link_12">View Instructor Profile</a>
                                            </div>
                                            <div class="night_mode_switch__btn">
                                                <a href="#" id="night-mode" class="btn-night-mode">
                                                    <i class="uil uil-moon"></i> Night mode
                                                    <span class="btn-night-mode-switch">
                                                        <span class="uk-switch-button"></span>
                                                    </span>
                                                </a>
                                            </div>
                                            <a href="instructor_dashboard.html" class="item channel_item">Cursus Dashboard</a>
                                            <a href="sign_in.html" class="item channel_item">Sign Out</a>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </header>


            <div class="wrapper _bg4586 _new89">
                <div class="_215b15">
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="title125">
                                    <div class="titleleft">
                                        <div class="ttl121">
                                            <nav aria-label="breadcrumb">
                                                <ol class="breadcrumb">
                                                    <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                                                    <li class="breadcrumb-item"><a href="certification_center.html">Certification Center</a></li>
                                                    <li class="breadcrumb-item active" aria-current="page">Result</li>
                                                </ol>
                                            </nav>
                                        </div>
                                    </div>
                                    <div class="titleright">
                                        <a href="certification_center.html" class="blog_link"><i class="uil uil-angle-double-left"></i>Back to Certification Center</a>
                                    </div>
                                </div>
                                <div class="title126">
                                    <h2>Result</h2>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="faq1256">
                    <div class="container">
                        <div class="row justify-content-md-center">
                            <div class="col-md-6">
                                <div class="certi_form rght1528">
                                    <div class="test_result_bg">
                                        <ul class="test_result_left">
                                            <li>
                                                <div class="result_dt">
                                                    <i class="uil uil-check right_ans"></i>
                                                    <p>Right<span>(15)</span></p>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="result_dt">
                                                    <i class="uil uil-times wrong_ans"></i>
                                                    <p>Wrong<span>(5)</span></p>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="result_dt">
                                                    <h4>15</h4>
                                                    <p>Out of 20</p>
                                                </div>
                                            </li>
                                        </ul>
                                        <div class="result_content">
                                            <h2>Congratulation! Joginder</h2>
                                            <p>You are eligible for this certificate</p>
                                            <a href="../../html-imgs/certificate.jpg" class="download_btn" download="w3logo" target="_blank">Download Certificate</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <Footer />
            </div>
        </>
    )
}
