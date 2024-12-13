/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { ArgsType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";
import { StaffAgencyWhereUniqueInput } from "./StaffAgencyWhereUniqueInput";
import { ValidateNested } from "class-validator";
import { Type } from "class-transformer";
import { StaffAgencyUpdateInput } from "./StaffAgencyUpdateInput";

@ArgsType()
class UpdateStaffAgencyArgs {
  @ApiProperty({
    required: true,
    type: () => StaffAgencyWhereUniqueInput,
  })
  @ValidateNested()
  @Type(() => StaffAgencyWhereUniqueInput)
  @Field(() => StaffAgencyWhereUniqueInput, { nullable: false })
  where!: StaffAgencyWhereUniqueInput;

  @ApiProperty({
    required: true,
    type: () => StaffAgencyUpdateInput,
  })
  @ValidateNested()
  @Type(() => StaffAgencyUpdateInput)
  @Field(() => StaffAgencyUpdateInput, { nullable: false })
  data!: StaffAgencyUpdateInput;
}

export { UpdateStaffAgencyArgs as UpdateStaffAgencyArgs };