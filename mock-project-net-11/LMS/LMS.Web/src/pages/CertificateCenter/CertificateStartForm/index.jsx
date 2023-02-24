import React, { useEffect, useState } from 'react';
import { Link , Redirect} from 'react-router-dom';
import { styled } from '@mui/material/styles';
import ArrowForwardIosSharpIcon from '@mui/icons-material/ArrowForwardIosSharp';
import MuiAccordion from '@mui/material/Accordion';
import MuiAccordionSummary from '@mui/material/AccordionSummary';
import MuiAccordionDetails from '@mui/material/AccordionDetails';
import Typography from '@mui/material/Typography';
import Footer from '../../../components/Footer';
import certificateAPI from '../../../api/certificateAPI';
import './style.css';
import { FormControl, FormControlLabel, FormLabel, Input, Radio, RadioGroup } from '@mui/material';
import { red } from '@mui/material/colors';
const Accordion = styled((props) => (
    <MuiAccordion disableGutters elevation={0} square {...props} />
))(({ theme }) => ({
    border: `1px solid ${theme.palette.divider}`,
    '&:not(:last-child)': {
        borderBottom: 0,
    },
    '&:before': {
        display: 'none',
    },
}));

const AccordionSummary = styled((props) => (
    <MuiAccordionSummary
        expandIcon={<ArrowForwardIosSharpIcon sx={{ fontSize: '0.9rem' }} />}
        {...props}
    />
))(({ theme }) => ({
    backgroundColor:
        theme.palette.mode === 'dark'
            ? 'rgba(255, 255, 255, .05)'
            : 'rgba(0, 0, 0, .03)',
    flexDirection: 'row-reverse',
    '& .MuiAccordionSummary-expandIconWrapper.Mui-expanded': {
        transform: 'rotate(90deg)',
    },
    '& .MuiAccordionSummary-content': {
        marginLeft: theme.spacing(1),
    },
}));

const AccordionDetails = styled(MuiAccordionDetails)(({ theme }) => ({
    padding: theme.spacing(2),
    borderTop: '1px solid rgba(0, 0, 0, .125)',
}));

export default function CertificateStartForm() {
    const [expanded, setExpanded] = React.useState('panel1');
    const [categories, setCategories] = useState([]);
    const [certificates, setCertificates] = useState([])
    const [selectedCategory, setSelectedCategory] = useState(0)
    const [filteredCertificate, setFilteredCertificate] = useState([]);
    const [selectedCertificate, setSelectedCertificate] = useState(1);
    const [isSumit, setIsSubmit]= useState(false);
    const handleChange = (panel) => (event, newExpanded) => {
        filterCertificateByCategory(panel)
        setSelectedCategory(panel);
        setExpanded(newExpanded ? panel : false);
    };

    function handleRadioChange(e) {
        setSelectedCertificate(e.target.value);
    }

    function filterCertificateByCategory(categoryId) {
        setFilteredCertificate(certificates.filter(x => x.certificateCategoryId == categoryId))
    }
    function handleLetsGoBtn(){
        console.log("dfsf")
        setIsSubmit(true);
    }

    useEffect(async () => {
        await certificateAPI.getAllCertificateCategory()
            .then(response => {
                setCategories(response.data.objects)
            })
            .catch(error => console.log(error))
    },[])

    useEffect(async () => {
        await certificateAPI.getAllCertificate()
            .then(response => {
                setCertificates(response.data);
                console.log(response.data)
            })
            .catch(error => {
                console.log(error)
            })
    }, [])
    if(isSumit){
        return (<Redirect to={`/certificate_center/certificate_test/${selectedCertificate}`}/>)
    }
    return (
        <>
            <header className="header clearfix">
                <div className="container">
                    <div className="row">
                        <div className="col-12">
                            <div className="back_link">
                                <Link to="/" className="hde151">Back To Cursus</Link>
                                <a href="index.html" className="hde152">Back</a>
                            </div>
                            <div className="ml_item">
                                <div className="main_logo main_logo15" id="logo">
                                    <a href="index.html"><img src="images/logo.svg" alt="" /></a>
                                    <a href="index.html"><img className="logo-inverse" src="images/ct_logo.svg" alt="" /></a>
                                </div>
                            </div>
                            <div className="header_right pr-0">
                                <ul>
                                    <li className="ui top right pointing dropdown">
                                        <a href="#" className="opts_account">
                                            <img src="images/hd_dp.jpg" alt="" />
                                        </a>
                                        <div className="menu dropdown_account">
                                            <div className="channel_my">
                                                <div className="profile_link">
                                                    <img src="images/hd_dp.jpg" alt="" />
                                                    <div className="pd_content">
                                                        <div className="rhte85">
                                                            <h6>Joginder Singh</h6>
                                                            <div className="mef78" title="Verify">
                                                                <i className='uil uil-check-circle'></i>
                                                            </div>
                                                        </div>
                                                        <span><a href="/cdn-cgi/l/email-protection" className="__cf_email__" data-cfemail="6a0d0b07080506535e592a0d070b030644090507">[email&#160;protected]</a></span>
                                                    </div>
                                                </div>
                                                <a href="my_instructor_profile_view.html" className="dp_link_12">View Instructor Profile</a>
                                            </div>
                                            <div className="night_mode_switch__btn">
                                                <a href="#" id="night-mode" className="btn-night-mode">
                                                    <i className="uil uil-moon"></i> Night mode
                                                    <span className="btn-night-mode-switch">
                                                        <span className="uk-switch-button"></span>
                                                    </span>
                                                </a>
                                            </div>
                                            <a href="instructor_dashboard.html" className="item channel_item">Cursus Dashboard</a>
                                            <a href="sign_in.html" className="item channel_item">Sign Out</a>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </header>


            <div className="wrapper _bg4586 _new89">
                <div className="_215b15">
                    <div className="container">
                        <div className="row">
                            <div className="col-lg-12">
                                <div className="title125">
                                    <div className="titleleft">
                                        <div className="ttl121">
                                            <nav aria-label="breadcrumb">
                                                <ol className="breadcrumb">
                                                    <li className="breadcrumb-item"><a href="index.html">Home</a></li>
                                                    <li className="breadcrumb-item"><a href="certification_center.html">Certification Center</a></li>
                                                    <li className="breadcrumb-item active" aria-current="page">Certification Fill Form</li>
                                                </ol>
                                            </nav>
                                        </div>
                                    </div>
                                    <div className="titleright">
                                        <Link to="/certificate_center" className="blog_link"><i className="uil uil-angle-double-left"></i>Back to Certification Center</Link>
                                    </div>
                                </div>
                                <div className="title126">
                                    <h2>Certification Fill Form</h2>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="faq1256">
                    <div className="container">
                        <div className="row justify-content-lg-center justify-content-md-center">
                            <div className="col-lg-6 col-md-8">
                                <div className="certi_form">
                                    <div className="sign_form">
                                        <h2>Select category before you start:</h2>
                                        <div>
                                        <RadioGroup
                                                  aria-labelledby="demo-controlled-radio-buttons-group"
                                                  name="controlled-radio-buttons-group"
                                              >
                                            {
                                                categories.map(category => (
                                                    <Accordion className="MuiAccordion-rounded " key={category.id} expanded={expanded === `${category.id}`} onChange={handleChange(`${category.id}`)}>
                                                        <AccordionSummary aria-controls={`${category.id}` + "d-content"} id={`${category.id}` + "d-header"}>
                                                            <Typography >{category.certificateCatgoryName}</Typography>
                                                        </AccordionSummary>
                                                        <AccordionDetails>
                                                            <FormControl className="sign_form ">
                                                                    {filteredCertificate.map(certificate=>(
                                                                    <FormControlLabel control={<Radio 
                                                                    sx={{
                                                                      color: '',
                                                                      '&.Mui-checked': {
                                                                        color: '#ed2a26',
                                                                      },
                                                                    }} onChange={handleRadioChange} value={certificate.id} />} label={certificate.certificateName}/>
                                                                    ))}
                                                            </FormControl> 
                                                          
                                                                {/* <FormControlLabel name='1' control={<Radio name='1'/>} label="fdsfd"/>
                                                                <FormControlLabel name='2' control={<Radio name='2'/>} label="fdsfd"/> */}
                                                        </AccordionDetails>
                                                    </Accordion>
                                                ))
                                            }
                                               </RadioGroup>
                                        </div>
                                        <p className="testtrm145">By signing up, you agree to our <a href="#">Privacy Policy</a> and <a href="#">Terms and Conditions</a>.</p>
                                        <button className="login-btn" onClick={handleLetsGoBtn}>Lets Go</button>
                                        <p className="questrm145">Please be ready to answer <span>20 questions</span> within <span>1 hours</span>.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

            <Footer />


        </>
    )
}
