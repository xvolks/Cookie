package com.ankamagames.dofus.network.types.game.character
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.BasicAllianceInformations;
   import com.ankamagames.dofus.network.types.game.context.roleplay.BasicGuildInformations;
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class CharacterMinimalAllianceInformations extends CharacterMinimalGuildInformations implements INetworkType
   {
      
      public static const protocolId:uint = 444;
       
      
      public var alliance:BasicAllianceInformations;
      
      private var _alliancetree:FuncTree;
      
      public function CharacterMinimalAllianceInformations()
      {
         this.alliance = new BasicAllianceInformations();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 444;
      }
      
      public function initCharacterMinimalAllianceInformations(param1:Number = 0, param2:String = "", param3:uint = 0, param4:EntityLook = null, param5:BasicGuildInformations = null, param6:BasicAllianceInformations = null) : CharacterMinimalAllianceInformations
      {
         super.initCharacterMinimalGuildInformations(param1,param2,param3,param4,param5);
         this.alliance = param6;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.alliance = new BasicAllianceInformations();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_CharacterMinimalAllianceInformations(param1);
      }
      
      public function serializeAs_CharacterMinimalAllianceInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_CharacterMinimalGuildInformations(param1);
         this.alliance.serializeAs_BasicAllianceInformations(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CharacterMinimalAllianceInformations(param1);
      }
      
      public function deserializeAs_CharacterMinimalAllianceInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.alliance = new BasicAllianceInformations();
         this.alliance.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CharacterMinimalAllianceInformations(param1);
      }
      
      public function deserializeAsyncAs_CharacterMinimalAllianceInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._alliancetree = param1.addChild(this._alliancetreeFunc);
      }
      
      private function _alliancetreeFunc(param1:ICustomDataInput) : void
      {
         this.alliance = new BasicAllianceInformations();
         this.alliance.deserializeAsync(this._alliancetree);
      }
   }
}
