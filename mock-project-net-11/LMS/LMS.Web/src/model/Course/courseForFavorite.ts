import AppUser from "../AppUser/appUser";
import Category from "../Category/category";

interface CourseForFavorite {
    id: number;
    title: string;
    price: number;
    thumbNailUrl: string;
    viewCount: number;
    totalDuration: number;
    updatedAt: string;
    averageRate: number;
    isBestSeller: boolean;
    appUser: AppUser;
    category: Category
}

export default CourseForFavorite;