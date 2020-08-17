package com.ankamagames.dofus.network.messages.game.alliance
{
   import com.ankamagames.dofus.network.types.game.guild.GuildEmblem;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class AllianceModificationValidMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6450;
       
      
      private var _isInitialized:Boolean = false;
      
      public var allianceName:String = "";
      
      public var allianceTag:String = "";
      
      public var Alliancemblem:GuildEmblem;
      
      private var _Alliancemblemtree:FuncTree;
      
      public function AllianceModificationValidMessage()
      {
         this.Alliancemblem = new GuildEmblem();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6450;
      }
      
      public function initAllianceModificationValidMessage(param1:String = "", param2:String = "", param3:GuildEmblem = null) : AllianceModificationValidMessage
      {
         this.allianceName = param1;
         this.allianceTag = param2;
         this.Alliancemblem = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.allianceName = "";
         this.allianceTag = "";
         this.Alliancemblem = new GuildEmblem();
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
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_AllianceModificationValidMessage(param1);
      }
      
      public function serializeAs_AllianceModificationValidMessage(param1:ICustomDataOutput) : void
      {
         param1.writeUTF(this.allianceName);
         param1.writeUTF(this.allianceTag);
         this.Alliancemblem.serializeAs_GuildEmblem(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AllianceModificationValidMessage(param1);
      }
      
      public function deserializeAs_AllianceModificationValidMessage(param1:ICustomDataInput) : void
      {
         this._allianceNameFunc(param1);
         this._allianceTagFunc(param1);
         this.Alliancemblem = new GuildEmblem();
         this.Alliancemblem.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AllianceModificationValidMessage(param1);
      }
      
      public function deserializeAsyncAs_AllianceModificationValidMessage(param1:FuncTree) : void
      {
         param1.addChild(this._allianceNameFunc);
         param1.addChild(this._allianceTagFunc);
         this._Alliancemblemtree = param1.addChild(this._AlliancemblemtreeFunc);
      }
      
      private function _allianceNameFunc(param1:ICustomDataInput) : void
      {
         this.allianceName = param1.readUTF();
      }
      
      private function _allianceTagFunc(param1:ICustomDataInput) : void
      {
         this.allianceTag = param1.readUTF();
      }
      
      private function _AlliancemblemtreeFunc(param1:ICustomDataInput) : void
      {
         this.Alliancemblem = new GuildEmblem();
         this.Alliancemblem.deserializeAsync(this._Alliancemblemtree);
      }
   }
}
