import { UserDto } from "../user/user.dto";
import { MatchDto } from "./match.dto";

export interface UserMatchDto {
    user: UserDto;
    match: MatchDto;
    value: string;
}