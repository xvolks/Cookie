package com.ankamagames.dofus.network.messages.game.context.roleplay.npc
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.BasicGuildInformations;
   import com.ankamagames.dofus.network.types.game.context.roleplay.BasicNamedAllianceInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class AllianceTaxCollectorDialogQuestionExtendedMessage extends TaxCollectorDialogQuestionExtendedMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6445;
       
      
      private var _isInitialized:Boolean = false;
      
      public var alliance:BasicNamedAllianceInformations;
      
      private var _alliancetree:FuncTree;
      
      public function AllianceTaxCollectorDialogQuestionExtendedMessage()
      {
         this.alliance = new BasicNamedAllianceInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6445;
      }
      
      public function initAllianceTaxCollectorDialogQuestionExtendedMessage(param1:BasicGuildInformations = null, param2:uint = 0, param3:uint = 0, param4:uint = 0, param5:uint = 0, param6:int = 0, param7:Number = 0, param8:Number = 0, param9:uint = 0, param10:Number = 0, param11:BasicNamedAllianceInformations = null) : AllianceTaxCollectorDialogQuestionExtendedMessage
      {
         super.initTaxCollectorDialogQuestionExtendedMessage(param1,param2,param3,param4,param5,param6,param7,param8,param9,param10);
         this.alliance = param11;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.alliance = new BasicNamedAllianceInformations();
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_AllianceTaxCollectorDialogQuestionExtendedMessage(param1);
      }
      
      public function serializeAs_AllianceTaxCollectorDialogQuestionExtendedMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_TaxCollectorDialogQuestionExtendedMessage(param1);
         this.alliance.serializeAs_BasicNamedAllianceInformations(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AllianceTaxCollectorDialogQuestionExtendedMessage(param1);
      }
      
      public function deserializeAs_AllianceTaxCollectorDialogQuestionExtendedMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.alliance = new BasicNamedAllianceInformations();
         this.alliance.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AllianceTaxCollectorDialogQuestionExtendedMessage(param1);
      }
      
      public function deserializeAsyncAs_AllianceTaxCollectorDialogQuestionExtendedMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._alliancetree = param1.addChild(this._alliancetreeFunc);
      }
      
      private function _alliancetreeFunc(param1:ICustomDataInput) : void
      {
         this.alliance = new BasicNamedAllianceInformations();
         this.alliance.deserializeAsync(this._alliancetree);
      }
   }
}
