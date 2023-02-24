import axiosClient from './axiosClient'

const adminAPI = {
  getAllUser(paging) {
    const url = `Admin/user?${paging}`
    return axiosClient.get(url, { paging })
  },
}
export default adminAPI
