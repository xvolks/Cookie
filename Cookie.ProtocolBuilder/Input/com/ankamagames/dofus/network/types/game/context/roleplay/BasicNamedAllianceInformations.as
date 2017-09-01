package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class BasicNamedAllianceInformations extends BasicAllianceInformations implements INetworkType
   {
      
      public static const protocolId:uint = 418;
       
      
      public var allianceName:String = "";
      
      public function BasicNamedAllianceInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 418;
      }
      
      public function initBasicNamedAllianceInformations(param1:uint = 0, param2:String = "", param3:String = "") : BasicNamedAllianceInformations
      {
         super.initBasicAllianceInformations(param1,param2);
         this.allianceName = param3;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.allianceName = "";
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_BasicNamedAllianceInformations(param1);
      }
      
      public function serializeAs_BasicNamedAllianceInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_BasicAllianceInformations(param1);
         param1.writeUTF(this.allianceName);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_BasicNamedAllianceInformations(param1);
      }
      
      public function deserializeAs_BasicNamedAllianceInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._allianceNameFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_BasicNamedAllianceInformations(param1);
      }
      
      public function deserializeAsyncAs_BasicNamedAllianceInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._allianceNameFunc);
      }
      
      private function _allianceNameFunc(param1:ICustomDataInput) : void
      {
         this.allianceName = param1.readUTF();
      }
   }
}
