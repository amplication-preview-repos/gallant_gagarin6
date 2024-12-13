/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { InputType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";
import {
  IsBoolean,
  IsOptional,
  IsString,
  MaxLength,
  ValidateNested,
} from "class-validator";
import { PayrollUpdateManyWithoutStaffItemsInput } from "./PayrollUpdateManyWithoutStaffItemsInput";
import { Type } from "class-transformer";
import { SkillUpdateManyWithoutStaffItemsInput } from "./SkillUpdateManyWithoutStaffItemsInput";
import { StaffAgencyWhereUniqueInput } from "../../staffAgency/base/StaffAgencyWhereUniqueInput";
import { UserWhereUniqueInput } from "../../user/base/UserWhereUniqueInput";

@InputType()
class StaffUpdateInput {
  @ApiProperty({
    required: false,
    type: Boolean,
  })
  @IsBoolean()
  @IsOptional()
  @Field(() => Boolean, {
    nullable: true,
  })
  availability?: boolean;

  @ApiProperty({
    required: false,
    type: String,
  })
  @IsString()
  @MaxLength(1000)
  @IsOptional()
  @Field(() => String, {
    nullable: true,
  })
  cv?: string;

  @ApiProperty({
    required: false,
    type: String,
  })
  @IsString()
  @IsOptional()
  @Field(() => String, {
    nullable: true,
  })
  email?: string;

  @ApiProperty({
    required: false,
    type: String,
  })
  @IsString()
  @MaxLength(1000)
  @IsOptional()
  @Field(() => String, {
    nullable: true,
  })
  name?: string;

  @ApiProperty({
    required: false,
    type: () => PayrollUpdateManyWithoutStaffItemsInput,
  })
  @ValidateNested()
  @Type(() => PayrollUpdateManyWithoutStaffItemsInput)
  @IsOptional()
  @Field(() => PayrollUpdateManyWithoutStaffItemsInput, {
    nullable: true,
  })
  payrolls?: PayrollUpdateManyWithoutStaffItemsInput;

  @ApiProperty({
    required: false,
    type: () => SkillUpdateManyWithoutStaffItemsInput,
  })
  @ValidateNested()
  @Type(() => SkillUpdateManyWithoutStaffItemsInput)
  @IsOptional()
  @Field(() => SkillUpdateManyWithoutStaffItemsInput, {
    nullable: true,
  })
  skills?: SkillUpdateManyWithoutStaffItemsInput;

  @ApiProperty({
    required: false,
    type: () => StaffAgencyWhereUniqueInput,
  })
  @ValidateNested()
  @Type(() => StaffAgencyWhereUniqueInput)
  @IsOptional()
  @Field(() => StaffAgencyWhereUniqueInput, {
    nullable: true,
  })
  staffAgency?: StaffAgencyWhereUniqueInput | null;

  @ApiProperty({
    required: false,
    type: () => UserWhereUniqueInput,
  })
  @ValidateNested()
  @Type(() => UserWhereUniqueInput)
  @IsOptional()
  @Field(() => UserWhereUniqueInput, {
    nullable: true,
  })
  user?: UserWhereUniqueInput | null;
}

export { StaffUpdateInput as StaffUpdateInput };