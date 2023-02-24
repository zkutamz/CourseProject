import axiosClient from './axiosClient';
const baseURL = 'https://lmsnet11be.azurewebsites.net';

const certificateAPI={
    async getAllCertificateCategory(){
        const url='/CertificateCategories';
        return await axiosClient.get(url) 
    },
    async getCertificates(params){
        const url=configGetCertificateURL(params);
        return await axiosClient.get(url);
    },
    async filterCertificateByCategory(params){
        const url= `/Certificates/FilterByCategory/${params}`;
        return await axiosClient.get(url);
    },
    async getAllCertificate(){
        const url= `/Certificates`;
        return await axiosClient.get(url);
    },
    async getCertificateTest(params){
        const url= `/Certificates/GetQuizzQuestionOfCertificate?certificateId=${params}&numberOfQuestion=20`;
        return await axiosClient.get(url);
    },
    async postUserAnswers(params){
        console.log("fsdfd: ",params)
        var url=  '/Certificates/ProcessingResultAndCertification';
        return await axiosClient.post(url, params);
    }
}

function configGetCertificateURL(params){
    let url= new URL(`api/Certificates`, baseURL);
    if(params!='')
    url.searchParams.append("keyword", params);
    return url;
}



export default certificateAPI;
