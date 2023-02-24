import React from 'react';
import './styles.css';
import categoryApi from '../../../api/categoryAPI';

class CategoryList extends React.Component {
    constructor(props) {
        super(props);
        this.state = { categoriesTemp: [] }
        this.cateClicked = this.cateClicked.bind(this);
    }

    componentDidMount() {
        this.loadCategories();
    }

    loadCategories() {
        categoryApi.getCategories().then(res => {
            try {
                this.setState({ categoriesTemp: res.data })
            }
            catch (error) {
                alert("Something went wrong: " + error);
            }
        });
    }

    cateClicked(cateObj) {
        this.props.parentCallback(cateObj);
    }

    render() {
        return (
            <>
                {
                    this.state.categoriesTemp.map(cate =>
                        <a onClick={(e) => this.cateClicked({id: cate.id, name: cate.name}, e)} className="item channel_item sub_menu--link item" key={cate.id}>{cate.name}</a>
                    )
                    // return ve object chua id va title
                }
            </>
        );
    }
}

export default CategoryList;