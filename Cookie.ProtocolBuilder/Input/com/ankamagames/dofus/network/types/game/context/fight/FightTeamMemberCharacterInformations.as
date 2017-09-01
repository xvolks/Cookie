package com.ankamagames.dofus.network.types.game.context.fight
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class FightTeamMemberCharacterInformations extends FightTeamMemberInformations implements INetworkType
   {
      
      public static const protocolId:uint = 13;
       
      
      public var name:String = "";
      
      public var level:uint = 0;
      
      public function FightTeamMemberCharacterInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 13;
      }
      
      public function initFightTeamMemberCharacterInformations(param1:Number = 0, param2:String = "", param3:uint = 0) : FightTeamMemberCharacterInformations
      {
         super.initFightTeamMemberInformations(param1);
         this.name = param2;
         this.level = param3;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.name = "";
         this.level = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_FightTeamMemberCharacterInformations(param1);
      }
      
      public function serializeAs_FightTeamMemberCharacterInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_FightTeamMemberInformations(param1);
         param1.writeUTF(this.name);
         if(this.level < 0 || this.level > 255)
         {
            throw new Error("Forbidden value (" + this.level + ") on element level.");
         }
         param1.writeByte(this.level);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FightTeamMemberCharacterInformations(param1);
      }
      
      public function deserializeAs_FightTeamMemberCharacterInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._nameFunc(param1);
         this._levelFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FightTeamMemberCharacterInformations(param1);
      }
      
      public function deserializeAsyncAs_FightTeamMemberCharacterInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._nameFunc);
         param1.addChild(this._levelFunc);
      }
      
      private function _nameFunc(param1:ICustomDataInput) : void
      {
         this.name = param1.readUTF();
      }
      
      private function _levelFunc(param1:ICustomDataInput) : void
      {
         this.level = param1.readUnsignedByte();
         if(this.level < 0 || this.level > 255)
         {
            throw new Error("Forbidden value (" + this.level + ") on element of FightTeamMemberCharacterInformations.level.");
         }
      }
   }
}
