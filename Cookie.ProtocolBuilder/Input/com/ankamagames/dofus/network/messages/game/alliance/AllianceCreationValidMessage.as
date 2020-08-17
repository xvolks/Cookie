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
   public class AllianceCreationValidMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6393;
       
      
      private var _isInitialized:Boolean = false;
      
      public var allianceName:String = "";
      
      public var allianceTag:String = "";
      
      public var allianceEmblem:GuildEmblem;
      
      private var _allianceEmblemtree:FuncTree;
      
      public function AllianceCreationValidMessage()
      {
         this.allianceEmblem = new GuildEmblem();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6393;
      }
      
      public function initAllianceCreationValidMessage(param1:String = "", param2:String = "", param3:GuildEmblem = null) : AllianceCreationValidMessage
      {
         this.allianceName = param1;
         this.allianceTag = param2;
         this.allianceEmblem = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.allianceName = "";
         this.allianceTag = "";
         this.allianceEmblem = new GuildEmblem();
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
         this.serializeAs_AllianceCreationValidMessage(param1);
      }
      
      public function serializeAs_AllianceCreationValidMessage(param1:ICustomDataOutput) : void
      {
         param1.writeUTF(this.allianceName);
         param1.writeUTF(this.allianceTag);
         this.allianceEmblem.serializeAs_GuildEmblem(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AllianceCreationValidMessage(param1);
      }
      
      public function deserializeAs_AllianceCreationValidMessage(param1:ICustomDataInput) : void
      {
         this._allianceNameFunc(param1);
         this._allianceTagFunc(param1);
         this.allianceEmblem = new GuildEmblem();
         this.allianceEmblem.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AllianceCreationValidMessage(param1);
      }
      
      public function deserializeAsyncAs_AllianceCreationValidMessage(param1:FuncTree) : void
      {
         param1.addChild(this._allianceNameFunc);
         param1.addChild(this._allianceTagFunc);
         this._allianceEmblemtree = param1.addChild(this._allianceEmblemtreeFunc);
      }
      
      private function _allianceNameFunc(param1:ICustomDataInput) : void
      {
         this.allianceName = param1.readUTF();
      }
      
      private function _allianceTagFunc(param1:ICustomDataInput) : void
      {
         this.allianceTag = param1.readUTF();
      }
      
      private function _allianceEmblemtreeFunc(param1:ICustomDataInput) : void
      {
         this.allianceEmblem = new GuildEmblem();
         this.allianceEmblem.deserializeAsync(this._allianceEmblemtree);
      }
   }
}
