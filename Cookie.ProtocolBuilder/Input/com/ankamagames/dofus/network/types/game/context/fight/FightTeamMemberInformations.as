package com.ankamagames.dofus.network.types.game.context.fight
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class FightTeamMemberInformations implements INetworkType
   {
      
      public static const protocolId:uint = 44;
       
      
      public var id:Number = 0;
      
      public function FightTeamMemberInformations()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 44;
      }
      
      public function initFightTeamMemberInformations(param1:Number = 0) : FightTeamMemberInformations
      {
         this.id = param1;
         return this;
      }
      
      public function reset() : void
      {
         this.id = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_FightTeamMemberInformations(param1);
      }
      
      public function serializeAs_FightTeamMemberInformations(param1:ICustomDataOutput) : void
      {
         if(this.id < -9007199254740990 || this.id > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.id + ") on element id.");
         }
         param1.writeDouble(this.id);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FightTeamMemberInformations(param1);
      }
      
      public function deserializeAs_FightTeamMemberInformations(param1:ICustomDataInput) : void
      {
         this._idFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FightTeamMemberInformations(param1);
      }
      
      public function deserializeAsyncAs_FightTeamMemberInformations(param1:FuncTree) : void
      {
         param1.addChild(this._idFunc);
      }
      
      private function _idFunc(param1:ICustomDataInput) : void
      {
         this.id = param1.readDouble();
         if(this.id < -9007199254740990 || this.id > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.id + ") on element of FightTeamMemberInformations.id.");
         }
      }
   }
}
