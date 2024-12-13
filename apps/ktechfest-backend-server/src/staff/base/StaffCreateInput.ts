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
  IsString,
  MaxLength,
  ValidateNested,
  IsOptional,
} from "class-validator";
import { PayrollCreateNestedManyWithoutStaffItemsInput } from "./PayrollCreateNestedManyWithoutStaffItemsInput";
import { Type } from "class-transformer";
import { SkillCreateNestedManyWithoutStaffItemsInput } from "./SkillCreateNestedManyWithoutStaffItemsInput";
import { StaffAgencyWhereUniqueInput } from "../../staffAgency/base/StaffAgencyWhereUniqueInput";
import { UserWhereUniqueInput } from "../../user/base/UserWhereUniqueInput";

@InputType()
class StaffCreateInput {
  @ApiProperty({
    required: true,
    type: Boolean,
  })
  @IsBoolean()
  @Field(() => Boolean)
  availability!: boolean;

  @ApiProperty({
    required: true,
    type: String,
  })
  @IsString()
  @MaxLength(1000)
  @Field(() => String)
  cv!: string;

  @ApiProperty({
    required: true,
    type: String,
  })
  @IsString()
  @Field(() => String)
  email!: string;

  @ApiProperty({
    required: true,
    type: String,
  })
  @IsString()
  @MaxLength(1000)
  @Field(() => String)
  name!: string;

  @ApiProperty({
    required: false,
    type: () => PayrollCreateNestedManyWithoutStaffItemsInput,
  })
  @ValidateNested()
  @Type(() => PayrollCreateNestedManyWithoutStaffItemsInput)
  @IsOptional()
  @Field(() => PayrollCreateNestedManyWithoutStaffItemsInput, {
    nullable: true,
  })
  payrolls?: PayrollCreateNestedManyWithoutStaffItemsInput;

  @ApiProperty({
    required: false,
    type: () => SkillCreateNestedManyWithoutStaffItemsInput,
  })
  @ValidateNested()
  @Type(() => SkillCreateNestedManyWithoutStaffItemsInput)
  @IsOptional()
  @Field(() => SkillCreateNestedManyWithoutStaffItemsInput, {
    nullable: true,
  })
  skills?: SkillCreateNestedManyWithoutStaffItemsInput;

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

export { StaffCreateInput as StaffCreateInput };
